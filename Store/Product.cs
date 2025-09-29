using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public abstract class Product
    {
        public string ProductName { get; private set; }
        public string Brand { get; private set; }
        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public Product(string name, string brand, int quantity, decimal price)
        {
            ProductName = name;
            Brand = brand;
            Price = price;
            Quantity = quantity;
        }



        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{ProductName} costs {Price} (In Stock :{Quantity}");
        }
        

    public void QuantityMinus(int q)
        {
            Quantity -= q;
        }
    
    public void QuantityPlus(int q)
        {
            Quantity += q;
        }
    }
}