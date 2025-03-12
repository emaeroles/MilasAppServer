namespace Application.DTOs.KioscoProduct
{
    public class UpdateKioscoProductPriceIuput
    {
        public Guid KioscoId { get; set; }
        public Guid ProductId { get; set; }
        public decimal KioscoSalePrice { get; set; }
    }
}
