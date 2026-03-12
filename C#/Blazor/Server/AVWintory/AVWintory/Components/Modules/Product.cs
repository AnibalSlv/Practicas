namespace AVWintory.Components.Modules;

public class Product
{
    public string Code { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public decimal PriceBase { get; set; }
    public decimal PriceOlder { get; set; }
    public decimal PriceSale { get; set; }
    public string NBill { get; set; }

    public Product(string code ,string description, string category ,decimal priceBase, decimal priceOlder,decimal priceSale, string nBill)
    {
        this.Code = code;
        this.Description = description;
        this.Category = category;
        this.PriceBase = priceBase;
        this.PriceOlder = priceOlder;
        this.PriceSale = priceSale;
        this.NBill = nBill;
    }
};