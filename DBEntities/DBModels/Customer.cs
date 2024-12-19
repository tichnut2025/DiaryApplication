using System;
using System.Collections.Generic;

namespace DBEntities.DBModels;

public partial class Customer
{
    public int CustId { get; set; }

    public string? CustName { get; set; }

    public string? CustAddress { get; set; }

    public string? CustCity { get; set; }

    public string? CustPhone { get; set; }

    public string? CustFax { get; set; }

    public int? EmpId { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();
}
