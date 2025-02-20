using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Visit
{
    public class AddVisitDetailInput
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Has { get; set; }
        [Required]
        public int Leave { get; set; }
        [Required]
        public int Changes { get; set; }
        [Required]
        public decimal HistSalePrice { get; set; }
    }
}
