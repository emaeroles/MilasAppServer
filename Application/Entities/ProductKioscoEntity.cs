namespace Application.Entities
{
    public class ProductKioscoEntity
    {
        public Guid ProductId { get; set; }
        public Guid KioscoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal KioscoSalePrice { get; set; }
        public int Stock { get; set; }
    }
}
