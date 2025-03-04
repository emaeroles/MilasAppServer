namespace Application.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsOwn {  get; set; }
        public decimal CostPrice {  get; set; }
        public decimal SalePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
