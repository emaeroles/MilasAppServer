using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Supply
{
    public class UpdateSupplyInput
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public float Quantity { get; set; }
        [Required]
        public string UoM { get; set; } = string.Empty;
        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public int Yeild { get; set; }
    }
}
