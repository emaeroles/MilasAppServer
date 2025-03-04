namespace Application.DTOs.Visit
{
    public class GetVisitDetailOutput
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Has { get; set; }
        public int Leave { get; set; }
        public int Changes { get; set; }
        public int Sold { get; set; }
        public decimal HistSalePrice { get; set; }
    }
}
