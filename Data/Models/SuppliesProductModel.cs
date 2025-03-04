using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class SuppliesProductModel
{
    public Guid Id { get; set; }

    public Guid SupplyId { get; set; }

    public Guid ProductId { get; set; }

    public virtual ProductModel Product { get; set; } = null!;

    public virtual SupplyModel Supply { get; set; } = null!;
}
