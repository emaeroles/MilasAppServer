namespace Application.DTOs.Visit
{
    public class AddVisitDetailInput
    {
        public Guid ProductId { get; set; }
        public int Has { get; set; }
        public int Leave { get; set; }
        public int Changes { get; set; }
    }
}
