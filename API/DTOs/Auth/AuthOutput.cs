namespace Application.DTOs.Auth
{
    public class AuthOutput
    {
        public object User { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
