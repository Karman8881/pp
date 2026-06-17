using System;
using System.Collections.Generic;

namespace dairy_farm.Models;

public partial class Specification
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Manufacturer { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Сontractor> Сontractors { get; set; } = new List<Сontractor>();
}
