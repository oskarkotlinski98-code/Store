using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{

    public class Customer
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public decimal Money { get; private set; }

        public static int NumberOfCustomers { get; private set; } = 0;

        private ShoppingCart shoppingCart = new ShoppingCart();

       

        public Customer(string name, string password,decimal money)
        {
            Name = name;
            Password = password;
            Money = money;
            shoppingCart =  new ShoppingCart();
            NumberOfCustomers++;
        }

        public static void InitializeCount(int count)
        {
            NumberOfCustomers = count;
        }

        



    }
}
