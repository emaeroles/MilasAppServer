namespace Application.Entities
{
    public class UomEntity
    {
        public Guid Id { get; set; }
        public string Unit { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
