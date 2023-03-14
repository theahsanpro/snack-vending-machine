using SnackVendingMachine.Users;
using System;

namespace SnackVendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User customer = new Customer();
            customer.DisplayMenu(new VendingMachine());

            int option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
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
                        User adminUser = new Admin();

                        Console.WriteLine("Please Choose an Option");
                        Console.WriteLine("1. Update Snack Price");
                        Console.WriteLine("2. Update Change Pool");
                        Console.WriteLine("3. Print Total Amount of money in the machine");

                        int opt = Convert.ToInt32(Console.ReadLine());

                        switch (opt)
                        {
                            case 1:
                                adminUser.DisplayMenu(new VendingMachine());

                                int item = Convert.ToInt32(Console.ReadLine());

                                

                                break;
                            case 2:
                                break;
                            case 3:
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



            //Console.WriteLine("Please Choose Your Role");
            //Console.WriteLine("1. Admin");
            //Console.WriteLine("2. Customer");

            //int opt1 = Convert.ToInt32(Console.ReadLine());

            //switch(opt1) {
            //    case 1:
            //        Console.WriteLine("Please enter your PIN");
            //        string pin = Console.ReadLine();
            //        Console.WriteLine("Please enter your Password");
            //        string pass = Console.ReadLine();

            //        if(pin == "1011" && pass == "A5144I")
            //        {
            //            User adminUser = new Admin();
            //            adminUser.DisplayMenu(vendingMachine);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Wrong Credentials. Please Check Again");
            //            Console.WriteLine("Press any key to continue ... ");
            //            Console.ReadKey();
            //        }

            //        break;
            //    case 2:
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
