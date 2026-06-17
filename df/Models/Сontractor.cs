using System;
using System.Collections.Generic;

namespace dairy_farm.Models;

public partial class Сontractor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Inn { get; set; }

    public string? Addres { get; set; }

    public string? Phone { get; set; }

    public sbyte? Salesman { get; set; }

    public sbyte? Buyer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
