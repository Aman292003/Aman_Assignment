using System;
using System.Collections.Generic;

namespace mvcefdemo.Models;

public partial class View1
{
    public string CustomerId { get; set; } = null!;

    public int OrderId { get; set; }

    public string? Expr1 { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? Freight { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? City { get; set; }
}
