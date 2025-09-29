using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ShoppingCart
    {
        public List<Product> listOfProducts = new List<Product>();

        public void AddProduct(Product product, int amount = 1)
        {
            listOfProducts.Add(product);
        }
    }
}
