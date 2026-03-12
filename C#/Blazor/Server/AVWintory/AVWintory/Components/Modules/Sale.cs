namespace AVWintory.Components.Modules;

public class Sale
{
    public string NBill { get; set; }
    public string Date { get; set; }
    public decimal Total { get; set; }
    public string Method { get; set; }
    //List<SaleDetail> Items { get; set; }

    public Sale(string nBill, string date, decimal total, string method)
    {
        this.NBill = nBill;
        this.Date = date;
        this.Total = total;
        this.Method = method;
        //this.Items = items;
    }
}