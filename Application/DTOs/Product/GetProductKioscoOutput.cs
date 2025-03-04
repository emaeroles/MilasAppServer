namespace Application.DTOs.Product
{
    public class GetProductKioscoOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal KioscoSalePrice { get; set; }
    }
}
