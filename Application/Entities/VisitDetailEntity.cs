namespace Application.Entities
{
    public class VisitDetailEntity
    {
        public Guid Id { get; set; }
        public ProductEntity Product { get; set; } = new ProductEntity();
        public int Has { get; set; }
        public int Leave { get; set; }
        public int Changes { get; set; }
        public int Sold { get; set; }
        public decimal HistSalePrice { get; set; }
    }
}
