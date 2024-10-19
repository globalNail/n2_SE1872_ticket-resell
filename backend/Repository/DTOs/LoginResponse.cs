public class LoginResponse
{
    public string Token { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public DateTime? Expired { get; set; }
}
