using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class SuppliesProductModel
{
    public int Id { get; set; }

    public int SupplyId { get; set; }

    public int ProductId { get; set; }

    public virtual ProductModel Product { get; set; } = null!;

    public virtual SupplyModel Supply { get; set; } = null!;
}
