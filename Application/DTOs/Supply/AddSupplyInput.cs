namespace Application.DTOs.Supply
{
    public class AddSupplyInput
    {
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public Guid UoMId { get; set; }
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
