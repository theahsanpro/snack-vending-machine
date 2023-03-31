using SnackVendingMachine.Users;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SnackVendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            User customer = new Customer(vendingMachine);

        startAgain:

            Console.Clear();
            customer.DisplayMenu();

            var number = Console.ReadLine();
            int option;
            bool isNumber = int.TryParse(number, out option);

            if(!isNumber)
            {
                Console.WriteLine("Please enter a valid option (From 1 to 5)");
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
                goto startAgain;
            }

            if (option > 0 && option < 7)
            {
                if (option != 6)
                {
                    (new Customer(vendingMachine)).MakePurchase(option);
                    goto startAgain;
                }
                else
                {
                    adminStartOver: 

                    Console.Clear();
                    Console.WriteLine("Welcome. This is an Admin Menu \n");
                    Console.WriteLine("Please enter your PIN or press B to go back to the Customer Menu");
                    string pin = Console.ReadLine();

                    if (pin.ToUpper() == "B")
                    {
                        goto startAgain;
                    }
                    else
                    {
                        Console.WriteLine("Please enter your Password");
                        string pass = Console.ReadLine();

                        if (pin == "1011" && pass == "A5144I")
                        {
                            User adminUser = new Admin(vendingMachine);

                        adminStart:
                            
                            Console.Clear();
                            Console.WriteLine("Please Choose an Option");
                            Console.WriteLine("1. Update Snack Price");
                            Console.WriteLine("2. Update Change Pool");
                            Console.WriteLine("3. Print Total Amount of money in the machine");
                            Console.WriteLine("4. Exit");

                            var num = Console.ReadLine();

                            int opt;
                            bool isNum = int.TryParse(num, out opt);

                            if (!isNum)
                            {
                                Console.WriteLine("Please enter a valid option (From 1 to 4)");
                                Console.WriteLine("\nPress any key to continue ...");
                                Console.ReadKey();
                                goto adminStart;
                            }

                            opt = Convert.ToInt32(num);

                            switch (opt)
                            {
                                case 1:
                                retry:
                                    adminUser.DisplayMenu();
                                    int item;

                                    try
                                    {
                                        item = Convert.ToInt32(Console.ReadLine());
                                        int[] options = { 1, 2, 3, 4, 5 };

                                        if (!options.Contains(item))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please Enter a valid option\n\n");
                                            goto retry;
                                        }
                                    }
                                    catch
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please Enter a valid option\n\n");
                                        goto retry;
                                    }

                                    (new Admin(vendingMachine)).UpdateSnackPrice(item);
                                    Console.WriteLine("\nUpdated Menu is : \n");
                                    adminUser.DisplayMenu();

                                    Console.WriteLine(" \nPress any key to go back to Admin menu");
                                    Console.ReadKey();
                                    goto adminStart;

                                    break;
                                case 2:
                                    (new Admin(vendingMachine)).IncreaseChangePool();
                                    Console.Clear();
                                    goto adminStart;

                                    break;
                                case 3:
                                    Console.WriteLine("Total Amount present in the Vending Machine is : £" +
                                        (new Admin(vendingMachine)).GetToalAmount());

                                    Console.Write("\nPlease press any key to continue ... ");
                                    Console.ReadKey();
                                    goto adminStart;
                                    break;
                                case 4:
                                    goto startAgain;
                                default:
                                    Console.WriteLine("Please Enter a valid option\n");
                                    Console.Write("\nPlease press any key to continue ... ");
                                    Console.ReadKey();
                                    goto adminStart;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Credentials. Please Check Again");
                            Console.WriteLine("Press any key to continue ... ");
                            Console.ReadKey();
                            goto adminStartOver;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Please Enter a Valid Option \n");
                Console.WriteLine("Press any key to continue ... ");
                Console.ReadKey();
                goto startAgain;
            }
        }
    }
}
