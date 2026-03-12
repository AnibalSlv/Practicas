namespace AVWintory.Components.Services.Sale;
using AVWintory.ModulesDb;

public interface ISaleService
{
    Sale? GetOneProductByNBill(string code);
    Task AddSale(Sale sale);
    Task DeleteSale(Sale sale);
    Task<(double[] Data, string[] Label)> GetSaleChart();
    Task Pay(decimal total, string mehotd, List<SaleDetail> items);
}