using System;
using System.Collections.Generic;

namespace dairy_farm.Models;

public partial class Production
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public DateOnly? Date { get; set; }

    public int OrderId { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
