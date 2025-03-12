using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class ProductModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsOwn { get; set; }

    public decimal CostPrice { get; set; }

    public decimal SalePrice { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<KioscoProductModel> KioscoProducts { get; set; } = new List<KioscoProductModel>();

    public virtual ICollection<VisitDetailModel> VisitDetails { get; set; } = new List<VisitDetailModel>();

    public virtual ICollection<SupplyModel> Supplies { get; set; } = new List<SupplyModel>();
}
