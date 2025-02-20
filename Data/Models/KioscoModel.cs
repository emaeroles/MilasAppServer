using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class KioscoModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsEnableChanges { get; set; }

    public string Notes { get; set; } = null!;

    public decimal Dubt { get; set; }

    public int? Order { get; set; }

    public int UserId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ProductsKioscoModel> ProductsKioscos { get; set; } = new List<ProductsKioscoModel>();

    public virtual UserModel User { get; set; } = null!;

    public virtual ICollection<VisitModel> Visits { get; set; } = new List<VisitModel>();
}
