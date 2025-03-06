namespace Application.Entities
{
    public class SupplyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public UomEntity Uom { get; set; } = new UomEntity();
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
        public bool IsActive { get; set; }
    }
}
