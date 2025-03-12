namespace Application.DTOs.KioscoProduct
{
    public class GetKioscoProductOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal KioscoSalePrice { get; set; }
    }
}
