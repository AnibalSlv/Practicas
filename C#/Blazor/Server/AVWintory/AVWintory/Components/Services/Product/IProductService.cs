namespace AVWintory.Components.Services.Product;
using AVWintory.ModulesDb;

public interface IProductService
{
    List<Product> GetProducts();
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
    Product? GetOneProductByCode(string code);
    
}