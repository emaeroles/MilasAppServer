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

    public virtual ICollection<ProductsKioscoEntity> ProductsKioscos { get; set; } = new List<ProductsKioscoEntity>();

    public virtual ICollection<SuppliesProductModel> SuppliesProducts { get; set; } = new List<SuppliesProductModel>();

    public virtual ICollection<VisitDetailModel> VisitDetails { get; set; } = new List<VisitDetailModel>();
}
