namespace Application.DTOs.KioscoProduct
{
    public class GetKioscoProductOutput
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal KioscoSalePrice { get; set; }
        public int Stock { get; set; }
    }
}
