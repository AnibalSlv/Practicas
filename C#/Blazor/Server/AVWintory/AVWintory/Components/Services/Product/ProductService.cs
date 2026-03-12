namespace AVWintory.Components.Services.Product;
using AVWintory.ModulesDb;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private List<Product> ListSale { get; set; } = new() {};
    
    private List<Product> ProductsList { get; set; } = new() { };
    
    private readonly IDbContextFactory <AVContext> _dbFactory;

    public ProductService(IDbContextFactory<AVContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }
    
    public List<Product> GetProducts()
    {
        var context = _dbFactory.CreateDbContext();
        return context.Products.ToList();
    }
    
    public Product? GetOneProductByCode(string code)
    {
        var context = _dbFactory.CreateDbContext();
        return context.Products.FirstOrDefault(p => p.Code == code);
    }
        
    public async Task AddProduct(Product product)
    {
        var context = _dbFactory.CreateDbContext();
        context.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateProduct(Product product)
    {
        using var context = _dbFactory.CreateDbContext();
    
        // 1. Buscamos el producto existente en la DB
        var existing = await context.Products
            .FirstOrDefaultAsync(p => p.Code == product.Code);

        if (existing != null)
        {
            existing.Description = product.Description;
            existing.Category = product.Category;
            existing.Stock = product.Stock; 
            existing.PriceBase = product.PriceBase;
            existing.PriceSale = product.PriceSale;
            existing.NBillProduct = product.NBillProduct;

            await context.SaveChangesAsync();
        }
    }
    
    public async Task DeleteProduct(Product product)
    {
        var context = _dbFactory.CreateDbContext();
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}