using System;
using System.Collections.Generic;

namespace Entytess;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int ProductId { get; set; }

    public int OrederId { get; set; }

    public int Quantity { get; set; }

    public virtual Order? Oreder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
