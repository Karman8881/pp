using System;
using System.Collections.Generic;

namespace dairy_farm.Models;

public partial class Material
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Unit { get; set; }

    public int? Quantity { get; set; }

    public double? SellPrice { get; set; }

    public double? BuyPrice { get; set; }

    public int SpecificationId { get; set; }

    public int ProductionId { get; set; }

    public virtual Production Production { get; set; } = null!;

    public virtual Specification Specification { get; set; } = null!;
}
