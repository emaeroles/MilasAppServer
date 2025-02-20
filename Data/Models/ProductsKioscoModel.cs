using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class ProductsKioscoModel
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int KioscoId { get; set; }

    public int Stock { get; set; }

    public decimal KioscoPrice { get; set; }

    public virtual KioscoModel Kiosco { get; set; } = null!;

    public virtual ProductModel Product { get; set; } = null!;
}
