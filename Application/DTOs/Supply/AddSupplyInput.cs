using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Supply
{
    public class AddSupplyInput
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public float Quantity { get; set; }
        [Required]
        public int UoMId { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public int Yeild { get; set; }
    }
}
