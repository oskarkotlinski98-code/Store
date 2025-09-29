using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Store
    {
        public List<Product> Inventory { get; private set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Inventory.Add(product);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Current inventory");
            foreach(Product p in Inventory)
            {
                p.DisplayInfo();

            }
            Console.WriteLine("Press key to continue");
            Console.ReadKey();
        }

        public bool SellProduct(string name, int amount)
        {
            Product product = Inventory.FirstOrDefault(p => p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product == null)
            {
                Console.WriteLine("Product not found");
                return false;
            }
            
            if (product.Quantity < amount)
            {
                Console.WriteLine($"Not enough {product.ProductName} in stock ");
                return false;
            }

            product.QuantityMinus(amount);
            Console.WriteLine($"Sold {amount} x {product.ProductName}. Remaining: {product.Quantity}");
            return true;

        }

    }
}
