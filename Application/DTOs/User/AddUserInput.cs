using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User
{
    public class AddUserInput
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
