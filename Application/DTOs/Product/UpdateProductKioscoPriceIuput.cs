namespace Application.DTOs.Product
{
    public class UpdateProductKioscoPriceIuput
    {
        public int ProductId { get; set; }
        public int KioscoId { get; set; }
        public decimal KioscoSalePrice { get; set; }
    }
}
