namespace Application.DTOs.Product
{
    public class GetProductKioscoOutput
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal KioscoSalePrice { get; set; }
    }
}
