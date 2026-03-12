namespace AVWintory.Components.Services.Sale;
using AVWintory.ModulesDb;
using Microsoft.EntityFrameworkCore;


public class SaleService : ISaleService
{
    private List<Sale> ListSale { get; set; } = new List<Sale>();
    
    private readonly IDbContextFactory <AVContext> _dbFactory;

    public SaleService(IDbContextFactory<AVContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<(double[] Data, string[] Label)> GetSaleChart()
    {
        using var _context = _dbFactory.CreateDbContext();
        /*
         * Se crea una lista data que es = a la lista ventas
         * Se utilizan operaciones LINQ:
         *      - Se selecciona la propiedad "Items" y se extraen todos los elementos que contiene manteniendo
         *        la referencia de "Sale"
         *      - Se agrupan los elementos con la categoria igual
         *      - Se seleciona solo el nombre de la categoria y se suma el precio de cada producto
         */

        var data = ListSale
            .SelectMany(
                sale => sale.Items, 
                (sale, items) => new { sale, items }
            )
            .GroupBy(x => x.items.PkProductNavigation.Category) 
            .Select(g => new
            {
                Label = g.Key ?? "Sin Categoría",
                Total = g.Sum(x => 
                    Convert.ToDouble(x.items.PriceMoment ?? "0") * Convert.ToDouble(x.items.Quantity ?? "0")
                )
            }).ToList();

        var dataChart = data.Select(x => x.Total).ToArray();
        var labelChart = data.Select(x => x.Label).ToArray();

        return (dataChart, labelChart);
        //return ListSale.Select(s => (double)s.Total).ToArray();
    }

    public Sale? GetOneProductByNBill(string nBill)
    {
        var context = _dbFactory.CreateDbContext();
        return context.Sales.FirstOrDefault(x => x.NBill == nBill);
    }
    
    public async Task AddSale(Sale sale)
    {
        var context = _dbFactory.CreateDbContext();
        context.Sales.Add(sale);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteSale(Sale sale)
    {
        var context = _dbFactory.CreateDbContext();
        context.Sales.Remove(sale);
        await context.SaveChangesAsync();
    }

    public async Task Pay(decimal total, string method, List<SaleDetail> items)
    {
        // Se clona la lista para que no desaparezca cuando elimine el espacio en la memoria
        var itemClone = new List<SaleDetail>(items);
        
        double rng = new Random().Next(1, 1000000000);
        int rngInt = (int)rng;
        string nBill = rngInt.ToString();
        
        string date = DateTime.Now.ToString("dd/MM/yyyy");

        var itemsBuy = new Sale{
            NBill = nBill, 
            Date = date, 
            Total = total.ToString(), 
            Method = method, 
            Items = itemClone
            };

        var _context = _dbFactory.CreateDbContext();
        
        _context.Sales.Add(itemsBuy);
        
        await _context.SaveChangesAsync();

        // AddSale(itemsBuy);
    }
}