using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ShoppingCart
    {
        private List<Product> listOfProducts = new List<Product>(); 

        public void AddProduct(Product product, int amount = 1)
        {
            listOfProducts.Add(product);
        }
        public void RemoveProduct(Product product, int amount = 1)
        {
            if (listOfProducts.Contains(product))
            {
                listOfProducts.Remove(product);
            }
            else
            {
                Console.WriteLine("Product not found in cart");
            }

        }
        public void ShowItemsInCart()
        {
            if (listOfProducts.Count == 0)
            {
                Console.WriteLine("Your cart is empty");
                return;
            }



            Console.WriteLine("These are the items in your cart!");
            foreach (Product p in listOfProducts)
            {
                p.CartInfo();
            }
        }
    }
}
