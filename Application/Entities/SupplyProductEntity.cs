namespace Application.Entities
{
    public class SupplyProductEntity
    {
        public Guid SupplyId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public UomEntity Uom { get; set; } = new UomEntity();
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
