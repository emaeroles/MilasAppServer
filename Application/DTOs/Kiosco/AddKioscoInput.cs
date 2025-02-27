namespace Application.DTOs.Kiosco
{
    public class AddKioscoInput
    {
        public string Name { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
