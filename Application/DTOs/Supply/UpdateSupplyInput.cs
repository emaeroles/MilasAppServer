namespace Application.DTOs.Supply
{
    public class UpdateSupplyInput
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public string UoM { get; set; } = string.Empty;
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
