using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User
{
    public class UpdateUserInput
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
