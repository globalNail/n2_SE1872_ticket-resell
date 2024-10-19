using Repository.DTOs.User;
using Repository.Models;

namespace Service.Interface;

public interface IAuthService
{
    Task<string> AuthenticateAsync(string firebaseToken);
    Task<UserDTO> GetOrCreateUserAsync(string firebaseUid, string email, string name, string role);
}
