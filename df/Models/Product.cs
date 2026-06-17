using System;
using System.Collections.Generic;

namespace dairy_farm.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public int SpecificationId { get; set; }

    public int ProductionId { get; set; }

    public virtual Production Production { get; set; } = null!;

    public virtual Specification Specification { get; set; } = null!;
}
