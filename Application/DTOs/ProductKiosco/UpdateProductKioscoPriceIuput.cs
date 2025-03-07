namespace Application.DTOs.ProductKiosco
{
    public class UpdateProductKioscoPriceIuput
    {
        public Guid KioscoId { get; set; }
        public Guid ProductId { get; set; }
        public decimal KioscoSalePrice { get; set; }
    }
}
