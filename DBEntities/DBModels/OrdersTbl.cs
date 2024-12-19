using System;
using System.Collections.Generic;

namespace DBEntities.DBModels;

public partial class OrdersTbl
{
    public int Ordnum { get; set; }

    public int? CustId { get; set; }

    public int? ProdId { get; set; }

    public int? Qty { get; set; }

    public DateOnly? Orddate { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual ProductsTbl? Prod { get; set; }
}
