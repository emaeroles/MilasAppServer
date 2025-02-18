namespace BL_Business.Entities
{
    public class VisitDetail
    {
        public int Id { get; set; }
        public Product Product { get; set; } = new Product();
        public int Has { get; set; }
        public int Leave { get; set; }
        public int Changes { get; set; }
        public int Sold { get; set; }
        public decimal HistSalePrice { get; set; }
    }
}
