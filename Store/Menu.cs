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


        public static void Show(Store store)
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
                        Customer LoggedIn = LogInUser();
                        { if (LoggedIn != null)
                            {
                                StoreMenu(LoggedIn,store);
                            }
                        }
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

        public static Customer LogInUser()
        {
            
            bool userFound = false;
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No user exists. Please register! , press any key to continue");
                Console.ReadKey();
                return null;

            }

            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 3 && parts[0] == username && parts[1] == password)
                {
                    userFound = true;
                    Console.WriteLine("Login successful, press any key to continue");
                    Console.ReadKey();
                    
                    return new Customer(parts[0], parts[1], Convert.ToDecimal(parts[2]));
                    

                }
                
            }
            if (!userFound)
            {
                Console.WriteLine("User not found or incorrect password, press any key to continue");
                Console.ReadKey();
            }
            return null;

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

        public static void StoreMenu(Customer c,Store s)
        {
            bool isInStore = true;

            while (isInStore)
            {
                Console.Clear();
                Console.WriteLine("Where would you like to go ");
                Console.WriteLine("[1].Meat section.\n[2].Drink section.\n[3].Snack section\n[4].Show Cart\n[5].Exit to login");
                string storeChoice = Console.ReadLine();

                switch (storeChoice)
                {
                    case "1":
                        Console.WriteLine("Welcome to the meat section");
                        Console.WriteLine("These are the items present in this section");
                        foreach(Meat m in s.Inventory)
                        {
                            m.DisplayInfo();
                        }

                        break;
                    case "2":
                        Console.WriteLine("Welcome to the Drink section");
                        Console.WriteLine("These are the items present in this section");
                        foreach (Drink d in s.Inventory)
                        {
                            d.DisplayInfo();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Welcome to the Snack section");
                        Console.WriteLine("These are the items present in this section");
                        foreach (Snack sn in s.Inventory)
                        {
                            sn.DisplayInfo();
                        }
                        break;
                    case "4":
                        c.shoppingCart.ShowItemsInCart();
                        break;
                    case "5":
                        Console.WriteLine("You've exited to login menu, press any key to continue");
                        Console.ReadKey();
                        isInStore = false;
                        break;
                        

                }
            }
        }
    }
}
