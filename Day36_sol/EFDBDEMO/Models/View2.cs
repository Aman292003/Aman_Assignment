using System;
using System.Collections.Generic;

namespace EFDBDEMO.Models;

public partial class View2
{
    public string CompanyName { get; set; } = null!;

    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public decimal? Total { get; set; }
}
