namespace Application.Entities
{
    public class KioscoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int UserId { get; set; }
        public bool IsEnableChanges { get; set; }
        public string Notes { get; set; } = string.Empty;
        public decimal Dubt { get; set; }
        public int Order { get; set; }
    }
}
