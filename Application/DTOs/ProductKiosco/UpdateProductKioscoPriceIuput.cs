namespace Application.DTOs.ProductKiosco
{
    public class UpdateProductKioscoPriceIuput
    {
        public Guid ProductId { get; set; }
        public Guid KioscoId { get; set; }
        public decimal KioscoSalePrice { get; set; }
    }
}
