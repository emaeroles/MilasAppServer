using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class ProductsKioscoEntity
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid KioscoId { get; set; }

    public int Stock { get; set; }

    public decimal KioscoPrice { get; set; }

    public virtual KioscoModel Kiosco { get; set; } = null!;

    public virtual ProductModel Product { get; set; } = null!;
}
