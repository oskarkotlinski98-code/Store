using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public static class Menu
    {
        static string filePath = "users.txt";


        public static void Show()
        {
            bool usingStore = true;
            while (usingStore)
            {
                Console.WriteLine("[1].Register\n[2].Login\n[4].Exit ");
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        RegisterCustomer();
                        break;
                    case "2":
                        LogInUser();
                        break;
                    case "3":
                        break;
                    case "4":
                        Console.WriteLine("You've exited the store");
                        usingStore = false;
                        break;
                }
            }

        }



        public static Customer RegisterCustomer()
        {
            string username;
            do
            {
                Console.WriteLine("Enter your Username");
                username = Console.ReadLine();
                if (DoesUserExist(username))
                {
                    Console.WriteLine("User already exists. Enter different username");

                }
                else
                {
                    break;
                }
            } while (true);

            Console.WriteLine("Enter you password");
            string password = Console.ReadLine();

            Console.WriteLine("Enter the amount of money on your account");
            decimal money = Convert.ToDecimal(Console.ReadLine());

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{username}|{password}|{money}");
            }

            Console.WriteLine("User succesfully registered , press key to continue");
            Console.ReadKey();
            

            return new Customer(username, password, money);
        }

        static void LogInUser()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No user exists. Please register! , press any key to continue");
                Console.ReadKey();
                return;

            }

            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            bool userFound = false;
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                {
                    userFound = true;
                    break;

                }
            }
            if (userFound)
            {
                Console.WriteLine("Login succesfull , press any button to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Login failed try again");
            }
        }

        static bool DoesUserExist(string username)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length >= 1 && parts[0].Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("User already exists, press key to continue");
                    Console.ReadKey();
                    return true;
                }
            }
            
            return false;
        }


        public static void LoadExistingCustomers()
        {
            if (File.Exists(filePath))
            {
                int count = File.ReadAllLines(filePath).Length;
                Customer.InitializeCount(count);
            }
            
        }

        public static void StoreMenu()
        {
            bool isInStore = true;

            while (isInStore)
            {
                Console.WriteLine("Where would you like to go ");
                Console.WriteLine("[1].Meat section.\n[2].Drink section.\n[3].Snack section\n Exit to login");
                string storeChoice = Console.ReadLine();

                switch (storeChoice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;

                }
            }
        }
    }
}
