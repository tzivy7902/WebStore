using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entytess;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? CategoryId { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public string? Img { get; set; }


    public virtual Category? Category { get; set; }


   
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
