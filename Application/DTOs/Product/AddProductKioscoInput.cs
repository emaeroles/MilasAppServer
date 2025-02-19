using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Product
{
    public class AddProductKioscoInput
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int KioscoId { get; set; }
    }
}
