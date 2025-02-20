using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class VisitDetailModel
{
    public int Id { get; set; }

    public int VisitId { get; set; }

    public int ProductId { get; set; }

    public int Has { get; set; }

    public int Leave { get; set; }

    public int Changes { get; set; }

    public int Sold { get; set; }

    public decimal HistSalePrice { get; set; }

    public virtual ProductModel Product { get; set; } = null!;

    public virtual VisitModel Visit { get; set; } = null!;
}
