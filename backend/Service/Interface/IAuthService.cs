using Repository.DTOs.Auth;
using Repository.DTOs.User;

namespace Service.Interface;

public interface IAuthService
{
    Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto);
    Task<AuthResponseDTO> LoginAsync(LoginDTORequest loginDto);
    Task<bool> ChangePasswordAsync(int userId, ChangePasswordDTO changePasswordDto);

}
