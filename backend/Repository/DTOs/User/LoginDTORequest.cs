namespace Repository.DTOs.User;

public class LoginDTORequest
{
    public string UsernameOrEmail { get; set; }
    
    public string Password { get; set; }
}
