using SnackVendingMachine.Users;
using System;

namespace SnackVendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine= new VendingMachine();

            User customer = new Customer(vendingMachine);
            customer.DisplayMenu();

            int option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
                    (new Customer(vendingMachine)).MakePurchase(option);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Welcome Admin");
                    Console.WriteLine("Please enter your PIN");
                    string pin = Console.ReadLine();
                    Console.WriteLine("Please enter your Password");
                    string pass = Console.ReadLine();

                    if (pin == "1011" && pass == "A5144I")
                    {
                        User adminUser = new Admin(vendingMachine);

                        Console.WriteLine("Please Choose an Option");
                        Console.WriteLine("1. Update Snack Price");
                        Console.WriteLine("2. Update Change Pool");
                        Console.WriteLine("3. Print Total Amount of money in the machine");

                        int opt = Convert.ToInt32(Console.ReadLine());

                        switch (opt)
                        {
                            case 1:
                                adminUser.DisplayMenu();

                                int item = Convert.ToInt32(Console.ReadLine());
                                (new Admin(vendingMachine)).UpdateSnackPrice(item);

                                adminUser.DisplayMenu();
                                break;
                            case 2:
                                (new Admin(vendingMachine)).IncreaseChangePool();
                                break;
                            case 3:
                                Console.WriteLine("Total Amount present in the Vending Machien is : £" + 
                                    (new Admin(vendingMachine)).GetToalAmount());
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials. Please Check Again");
                        Console.WriteLine("Press any key to continue ... ");
                        Console.ReadKey();
                    }
                    break;
                default:
                    break;

            }
        }
    }
}
