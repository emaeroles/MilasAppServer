using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Kiosco
{
    public class AddKioscoInput
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Manager { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int UserId { get; set; }
    }
}
