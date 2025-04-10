﻿namespace Application.Entities
{
    public class VisitEntity
    {
        public Guid Id { get; set; }
        public KioscoEntity Kiosco { get; set; } = new KioscoEntity();
        public DateTime Date { get; set; } = new DateTime();
        public List<VisitDetailEntity> VisitDetails { get; set; } = new List<VisitDetailEntity>();
    }
}
