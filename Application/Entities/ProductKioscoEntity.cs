namespace Application.Entities
{
    public class ProductKioscoEntity
    {
        public int ProductId { get; set; }
        public int KioscoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal KioscoSalePrice { get; set; }
        public int Stock { get; set; }
    }
}
