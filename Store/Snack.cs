using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Snack : Product
    {
        public Snack(string name, string brand, int quantity, decimal price) : base(name, brand, quantity, price)
        {
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
        }

    }
}
