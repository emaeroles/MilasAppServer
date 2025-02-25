namespace Application.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsOwn {  get; set; }
        public decimal CostPrice {  get; set; }
        public decimal SalePrice { get; set; }
    }
}
