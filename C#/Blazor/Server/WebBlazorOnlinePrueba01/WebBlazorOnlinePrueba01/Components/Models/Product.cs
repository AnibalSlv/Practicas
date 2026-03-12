namespace WebBlazorOnlinePrueba01.Components.Models
{
    public class Product
    {
        public double Price;
        public string Name;
        public string Description;
        public double price2;
        public int CounterProduct;

        public Product(string name, double price, string description, double price2, int counterProduct)
        {
            Name = name;
            Price = price;
            Description = description;
            CounterProduct = counterProduct;
        }
        public Product(string name, double price, double price2, int counterProduct)
        {
            Name = name;
            Price = price;
            Description = "";
            CounterProduct = counterProduct;
        }
    }
}
