namespace Application.DTOs.Visit
{
    public class AddVisitInput
    {
        public int KioscoId { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public AddVisitDetailInput[] VisitDetails { get; set; } = [];
    }
}
