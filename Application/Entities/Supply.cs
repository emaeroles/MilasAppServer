namespace BL_Business.Entities
{
    public class Supply
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public UoM UoM { get; set; } = new UoM();
        public decimal CostPrice { get; set; }
        public int Yeild { get; set; }
    }
}
