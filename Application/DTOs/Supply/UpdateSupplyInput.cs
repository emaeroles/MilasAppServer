namespace Application.DTOs.Supply
{
    public class UpdateSupplyInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public Guid UomId { get; set; }
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
