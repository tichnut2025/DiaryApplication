using System;
using System.Collections.Generic;

namespace DBEntities.Models;

public partial class ProductsTbl
{
    public int ProdId { get; set; }

    public string? ProdDesc { get; set; }

    public int? CostBuy { get; set; }

    public double CostSale { get; set; }

    public int? QtyStock { get; set; }

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();
}
