using System;
using System.Collections.Generic;

namespace Demo1WebApi.DataAccess;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
