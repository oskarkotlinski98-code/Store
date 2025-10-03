using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Staff
    {
        public void OrderProducts(Store store)
        {
            Console.WriteLine("Ordering products...");
            Console.WriteLine("What product would you like to order?");
            Console.WriteLine("[1] Meat\n[2].Drinks\n[3].Snacks");
            string orderChoice = Console.ReadLine();
            bool ordering = true;
            while (ordering)
            {
                switch (orderChoice)
                {


                    case "1":
                        Console.WriteLine("Which meat product would you like to order?\n Enter name of the product:");
                        string meatName = Console.ReadLine();
                        Console.WriteLine("Enter brand of the product:");
                        string meatBrand = Console.ReadLine();
                        Console.WriteLine("Enter quantity:");
                        int meatQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Selling price of the item:");
                        decimal meatPrice = Convert.ToDecimal(Console.ReadLine());
                        Meat newMeat = new Meat(meatName, meatBrand, meatQuantity, meatPrice);
                        store.AddProduct(newMeat);

                        break;
                    case "2":

                        Console.WriteLine("Which drink product would you like to order?\n Enter name of the product:");
                        string drinkName = Console.ReadLine();
                        Console.WriteLine("Enter brand of the product:");
                        string drinkBrand = Console.ReadLine();
                        Console.WriteLine("Enter quantity:");
                        int drinkQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Selling price of the item:");
                        decimal drinkPrice = Convert.ToDecimal(Console.ReadLine());
                        Drink newDrink = new Drink(drinkName, drinkBrand, drinkQuantity, drinkPrice);
                        store.AddProduct(newDrink);

                        break;

                    case "3":
                        Console.WriteLine("Which snack product would you like to order?\n Enter name of the product:");
                        string snackName = Console.ReadLine();
                        Console.WriteLine("Enter brand of the product:");
                        string snackBrand = Console.ReadLine();
                        Console.WriteLine("Enter quantity:");
                        int snackQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Selling price of the item:");
                        decimal snackPrice = Convert.ToDecimal(Console.ReadLine());
                        Snack newSnack = new Snack(snackName, snackBrand, snackQuantity, snackPrice);
                        store.AddProduct(newSnack);
                        break;

                    default:
                        Console.WriteLine("Invalid choice, returning to main menu.");
                        ordering = false;

                        break;
                }
            }
        }
    }
}
