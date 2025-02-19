using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Product
{
    public class UpdateProductKioscoPriceIuput
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int KioscoId { get; set; }
        [Required]
        public decimal KioscoSalePrice { get; set; }
    }
}
