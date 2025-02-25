namespace Application.Entities
{
    public class SupplyProductEntity
    {
        public int SupplyId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public UoMEntity UoM { get; set; } = new UoMEntity();
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
