using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class VisitModel
{
    public int Id { get; set; }

    public int KioscoId { get; set; }

    public DateTime Date { get; set; }

    public virtual KioscoModel Kiosco { get; set; } = null!;

    public virtual ICollection<VisitDetailModel> VisitDetails { get; set; } = new List<VisitDetailModel>();
}
