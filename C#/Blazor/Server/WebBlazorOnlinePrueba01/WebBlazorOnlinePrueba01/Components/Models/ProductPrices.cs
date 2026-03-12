namespace WebBlazorOnlinePrueba01.Components.Models
{
    public class ProductPrices
    {
        public static void EqualizationPrice(Product product)
        {
            product.price2 = product.Price;
        }

        public static void IncrementPrice(Product product)
        {
            if (product.CounterProduct != 0)
            {
                product.price2 += product.Price;
                product.price2 = Math.Round(product.price2, 3);
                product.CounterProduct++;
            }
            else
            {
                product.CounterProduct++;
            }
        }

        public static void DecrementPrice(Product product)
        {
            if (product.CounterProduct > 0)
            {
                product.CounterProduct--;
                product.price2 -= product.Price;
                product.price2 = Math.Round(product.price2, 3);
                if (product.CounterProduct == 0)
                {
                    product.price2 = product.Price;
                    product.CounterProduct = 0;
                }
            }
        }
    }
}
