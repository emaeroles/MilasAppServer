using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class KioscoModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public Guid UserId { get; set; }

    public bool IsEnableChanges { get; set; }

    public string Notes { get; set; } = null!;

    public decimal Dubt { get; set; }

    public Guid Order { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<KioscoProductModel> KioscoProducts { get; set; } = new List<KioscoProductModel>();

    public virtual UserModel User { get; set; } = null!;

    public virtual ICollection<VisitModel> Visits { get; set; } = new List<VisitModel>();
}
