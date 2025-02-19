using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Kiosco
{
    public class UpdateKioscoNoteInput
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; } = string.Empty;
    }
}
