using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class UomModel
{
    public Guid Id { get; set; }

    public string Unit { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<SupplyModel> Supplies { get; set; } = new List<SupplyModel>();
}
