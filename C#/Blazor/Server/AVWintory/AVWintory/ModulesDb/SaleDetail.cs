using System;
using System.Collections.Generic;

namespace AVWintory.ModulesDb;

public partial class SaleDetail
{
    public int IdSaleDetail { get; set; }

    public string? PkProduct { get; set; }

    public string? Quantity { get; set; }

    public string? PriceMoment { get; set; }

    public virtual Product? PkProductNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
