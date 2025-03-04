namespace Application.DTOs.Product
{
    public class UpdateProductKioscoPriceIuput
    {
        public Guid ProductId { get; set; }
        public Guid KioscoId { get; set; }
        public decimal KioscoSalePrice { get; set; }
    }
}
