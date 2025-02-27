namespace Application.DTOs.Visit
{
    public class GetVisitOutput
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public GetVisitDetailOutput[] VisitDetails { get; set; } = [];
    }
}
