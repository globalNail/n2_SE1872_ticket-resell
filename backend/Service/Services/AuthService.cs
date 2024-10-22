using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.DTOs.Auth;
using Repository.DTOs.User;
using Repository.Models;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto)
    {
        var existingUser = await _unitOfWork.UserRepository.GetByUsernameOrEmailAsync(registerDto.Username);
        if (existingUser != null)
        {
            throw new Exception("Username hoặc Email đã tồn tại.");
        }

        var user = _mapper.Map<User>(registerDto);
        user.PasswordHash = _passwordHasher.HashPassword(user, registerDto.Password);

        // Gán quyền mặc định "User"
        var userRole = await _unitOfWork.UserRoleRepository.GetByNameAsync("buyer");
        if (userRole == null)
        {
            throw new Exception("Default role not found.");
        }

        user.RoleId = userRole.RoleId;


        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        var token = await GenerateJwtToken(user);

        return new AuthResponseDTO
        {
            Token = token,
            Username = user.Username,
            Email = user.Email
        };

    }

    public async Task<AuthResponseDTO> LoginAsync(LoginDTORequest loginDto)
    {
        var user = await _unitOfWork.UserRepository.GetByUsernameOrEmailAsync(loginDto.UsernameOrEmail);
        if (user == null)
        {
            throw new Exception("Username hoặc Email không tồn tại.");
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new Exception("Mật khẩu không chính xác.");
        }

        var token = await GenerateJwtToken(user);

        return new AuthResponseDTO
        {
            Token = token,
            Username = user.Username,
            Email = user.Email
        };
    }
    public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDTO changePasswordDto)
    {
        // Lấy người dùng từ cơ sở dữ liệu
        var user = await _unitOfWork.UserRepository.GetAsync(u => u.UserId == userId);
        if (user == null)
        {
            throw new Exception("Người dùng không tồn tại.");
        }

        // Xác thực mật khẩu hiện tại
        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, changePasswordDto.CurrentPassword);
        if (verificationResult == PasswordVerificationResult.Failed)
        {
            throw new Exception("Mật khẩu hiện tại không chính xác.");
        }

        // Hash mật khẩu mới
        user.PasswordHash = _passwordHasher.HashPassword(user, changePasswordDto.NewPassword);

        // Cập nhật người dùng
        _unitOfWork.UserRepository.Update(user);

        // Lưu thay đổi
        await _unitOfWork.SaveChangesAsync();

        return true;
    }



    private async Task<string> GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secret = jwtSettings.GetValue<string>("Secret");
        var issuer = jwtSettings.GetValue<string>("Issuer");
        var audience = jwtSettings.GetValue<string>("Audience");
        var expiryMinutes = jwtSettings.GetValue<int>("ExpiryMinutes");
        Console.WriteLine($"Secret: {secret}");
        Console.WriteLine($"Issuer: {issuer}");
        Console.WriteLine($"Audience: {audience}");
        Console.WriteLine($"ExpiryMinutes: {expiryMinutes}");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new System.Collections.Generic.List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        // Thêm các quyền của người dùng vào claims
        var role = await _unitOfWork.UserRoleRepository.GetAsync(r => r.RoleId == user.RoleId);
        if (role != null)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
        }

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
