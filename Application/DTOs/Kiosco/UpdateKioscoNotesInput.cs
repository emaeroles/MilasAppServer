using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Kiosco
{
    public class UpdateKioscoNotesInput
    {
        public int Id { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
