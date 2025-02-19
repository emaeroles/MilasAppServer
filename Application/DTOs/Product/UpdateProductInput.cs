using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Product
{
    public class UpdateProductInput
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool IsOwn { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
    }
}
