﻿using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class SupplyModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public float Quantity { get; set; }

    public Guid UomId { get; set; }

    public decimal CostPrice { get; set; }

    public int Yeild { get; set; }

    public bool IsActive { get; set; }

    public virtual UomModel Uom { get; set; } = null!;

    public virtual ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
}
