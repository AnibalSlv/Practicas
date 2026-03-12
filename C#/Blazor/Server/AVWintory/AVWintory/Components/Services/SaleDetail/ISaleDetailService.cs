namespace AVWintory.Components.Services.SaleDetail;
using AVWintory.ModulesDb;

public interface ISaleDetailService
{
    SaleDetail? GetOneProductByCode(string nBill);
    List<SaleDetail> GetSaleDetail();
    Task AddSaleDetail(SaleDetail saleDetail);
    Task DeleteSaleDetail(SaleDetail saleDetail);
    decimal GetTotalSaleDetail(Product product, int quantity);
}