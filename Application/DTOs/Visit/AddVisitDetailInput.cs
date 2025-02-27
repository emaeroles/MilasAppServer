namespace Application.DTOs.Visit
{
    public class AddVisitDetailInput
    {
        public int ProductId { get; set; }
        public int Has { get; set; }
        public int Leave { get; set; }
        public int Changes { get; set; }
        public decimal HistSalePrice { get; set; }
    }
}
