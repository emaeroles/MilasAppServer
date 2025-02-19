using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Kiosco
{
    public class UpdateKioscoDubtInput
    {
        [Required]
        public int Id { get; set; }
    }
}
