namespace AVWintory.Components.Services.SaleDetail;
using AVWintory.ModulesDb;
using Microsoft.EntityFrameworkCore;

public class SaleDetailService : ISaleDetailService
{
    private decimal _total;

    private List<SaleDetail> ListSaleDetail { get; set; } = new List<SaleDetail>();
    
    private readonly IDbContextFactory <AVContext> _dbFactory;

    public SaleDetailService(IDbContextFactory<AVContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }


    public List<SaleDetail> GetSaleDetail()
    {
        var context =  _dbFactory.CreateDbContext();
        return context.SaleDetails.ToList();
    }
    
    public SaleDetail? GetOneProductByCode(string code)
    {
        return ListSaleDetail.FirstOrDefault(s => s.PkProduct == code );
    }
    
    public async Task AddSaleDetail(SaleDetail saleDetail)
    {
        var context =  _dbFactory.CreateDbContext();
        context.SaleDetails.Add(saleDetail);
        Console.WriteLine("Confirmo que si guardo");
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteSaleDetail(SaleDetail saleDetail)
    {
        var context = _dbFactory.CreateDbContext();
        context.SaleDetails.Remove(saleDetail);
        await context.SaveChangesAsync();
    }

    public decimal GetTotalSaleDetail(Product product, int quantity)
    {
        return _total += int.Parse(product.PriceSale) * quantity;
    }
}