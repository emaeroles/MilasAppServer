namespace BL_Business.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public Kiosco Kiosco { get; set; } = new Kiosco();
        public DateTime Date { get; set; } = new DateTime();
        public VisitDetail[] VisitDetails { get; set; } = [];
    }
}
