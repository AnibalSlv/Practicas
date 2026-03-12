using System;
using System.Collections.Generic;

namespace AVWintory.ModulesDb;

public partial class Product
{
    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Stock { get; set; }

    public string? PriceBase { get; set; }

    public string? PriceSale { get; set; }

    public string? NBillProduct { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
