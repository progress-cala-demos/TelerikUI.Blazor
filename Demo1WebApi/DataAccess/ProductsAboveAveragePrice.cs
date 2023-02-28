using System;
using System.Collections.Generic;

namespace Demo1WebApi.DataAccess;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
