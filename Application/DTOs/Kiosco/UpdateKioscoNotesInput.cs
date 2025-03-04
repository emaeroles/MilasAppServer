namespace Application.DTOs.Kiosco
{
    public class UpdateKioscoNotesInput
    {
        public Guid Id { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
