using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class VisitModel
{
    public Guid Id { get; set; }

    public Guid KioscoId { get; set; }

    public DateTime Date { get; set; }

    public virtual KioscoModel Kiosco { get; set; } = null!;

    public virtual ICollection<VisitDetailModel> VisitDetails { get; set; } = new List<VisitDetailModel>();
}
