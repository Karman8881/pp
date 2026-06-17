using System;
using System.Collections.Generic;

namespace dairy_farm.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public DateOnly? Date { get; set; }

    public string? Salesman { get; set; }

    public string? Buyer { get; set; }

    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();

    public virtual ICollection<Сontractor> Сontractors { get; set; } = new List<Сontractor>();
}
