using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Kiosco
{
    public class UpdateKioscoOrderInput
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Oreder { get; set; }
    }
}
