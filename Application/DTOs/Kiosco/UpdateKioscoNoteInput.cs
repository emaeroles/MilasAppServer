using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Kiosco
{
    public class UpdateKioscoNoteInput
    {
        public int Id { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
