using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Visit
{
    public class AddVisitInput
    {
        [Required]
        public int KioscoId { get; set; }
        [Required]
        public DateTime Date { get; set; } = new DateTime();
        [Required]
        public AddVisitDetailInput[] VisitDetails { get; set; } = [];
    }
}
