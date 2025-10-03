using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Meat : Product
    {
        public Meat(string name, string brand, int quantity, decimal price) : base(name, brand, quantity, price)
        {
        }

        public static int ItemCount { get; private set; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
        }

    }
}
