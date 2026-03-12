using System;
using System.Collections.Generic;

namespace AVWintory.ModulesDb;

public partial class Sale
{
    public string NBill { get; set; } = null!;

    public string? Date { get; set; }

    public string? Total { get; set; }

    public string? Method { get; set; }

    public int? PkSaleDetail { get; set; }

    public virtual SaleDetail? PkSaleDetailNavigation { get; set; }
    
    public virtual ICollection<SaleDetail> Items { get; set; } = new List<SaleDetail>();

}
