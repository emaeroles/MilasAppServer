namespace BL_Business.Entities
{
    public class SupplyProduct
    {
        public int SupplyId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public UoM UoM { get; set; } = new UoM();
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
