using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Supply
{
    public class AddSuppyProductInput
    {
        [Required]
        public int SupplyId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
