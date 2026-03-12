using Microsoft.AspNetCore.Components;
using WebBlazorOnlinePrueba01.Components.Models;

namespace WebBlazorOnlinePrueba01.Components.Pages
{
    public partial class Home : ComponentBase
    {
        List<Product> products = new List<Product>();

        Product product1 = new Product("Manzana", 1.40, 1.40, 0);
        Product product2 = new Product("Cereal", 2.30, "Nutritivo", 2.30, 0);
        Product product3 = new Product("Chocolate", 0.40, "Anti Depresivo", 0.40, 0);
        Product product4 = new Product("Arroz", 3.40, 3.40, 0);
        Product product5 = new Product("Telefono", 100, "Iphone", 100, 0);
        Product product6 = new Product("TV", 300, "LG", 300, 0);
        Product product7 = new Product("TV", 200, "Google", 200, 0);

        protected override void OnInitialized()
        {
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product7);

            foreach (var product in products)
            {
                ProductPrices.EqualizationPrice(product);
            }
        }
    }
}
