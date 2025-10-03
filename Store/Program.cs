namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Menu.LoadExistingCustomers();
            Menu.Show(store);
            

        }
    }
}
