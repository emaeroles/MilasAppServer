namespace Application.DTOs.Supply
{
    public class GetSupplyOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public string Uom { get; set; } = string.Empty;
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
