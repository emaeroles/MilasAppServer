namespace Application.DTOs.Visit
{
    public class AddVisitInput
    {
        public Guid KioscoId { get; set; }
        public AddVisitDetailInput[] VisitDetails { get; set; } = [];
    }
}
