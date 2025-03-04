namespace Application.DTOs.Supply
{
    public class UpdateUomInput
    {
        public Guid Id { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
