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
            //this is the main program entry 
            //we create a vendinc machine object to get access to the lists it has implemented inside , later on 
            VendingMachine vendingMachine = new VendingMachine();
            //and we use polymorphism and create a customer object to use its methods
            User customer = new Customer(vendingMachine);

            //where the magic starts:
        startAgain:

            Console.Clear();
            //display the customer menu 
            customer.DisplayMenu();

            //take the input 
            var number = Console.ReadLine();

            int option;
            //converte it into true or false case
            bool isNumber = int.TryParse(number, out option);

            //if false , and the number is not a number or valid input

            if(!isNumber)
            {
                //print this and start over
                Console.WriteLine("Please enter a valid option (From 1 to 5)");
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
                goto startAgain;
            }

            //if the input is correct , so between 1-6
            if (option > 0 && option < 7)
            {
                //so if option is not 6 (were 6 is the hidden admin menu)
                if (option != 6)
                {
                    //call the customer make purchase (take the number option value)
                    (new Customer(vendingMachine)).MakePurchase(option);
                    goto startAgain;
                }
                else
                {
                    adminStartOver: 

                    //else the user presses 6 , means is admin , and goes to admin menu
                    Console.Clear();
                    Console.WriteLine("Welcome. This is an Admin Menu \n");
                    Console.WriteLine("Please enter your PIN or press B to go back to the Customer Menu");
                    string pin = Console.ReadLine();

                    //if it goes to the menu accidently , has a back B key option that sends the user back to customer menu
                    if (pin.ToUpper() == "B")
                    {
                        goto startAgain;
                    }
                    else
                    {
                        //else if it was admin and enter the correct pin and password
                        Console.WriteLine("Please enter your Password");
                        string pass = Console.ReadLine();

                        //if correct 
                        if (pin == "1011" && pass == "A5144I")
                        {
                            //create adminuser object to have the right and use the methods
                            User adminUser = new Admin(vendingMachine);

                        adminStart:
                            
                            //the admin menu interface
                            Console.Clear();
                            Console.WriteLine("Please Choose an Option");
                            Console.WriteLine("1. Update Snack Price");
                            Console.WriteLine("2. Update Change Pool");
                            Console.WriteLine("3. Print Total Amount of money in the machine");
                            Console.WriteLine("4. Exit");

                            var num = Console.ReadLine();

                            int opt;
                            //converte it into true or false case
                            bool isNum = int.TryParse(num, out opt);

                            //if false , and the number is not a number or valid input

                            if (!isNum)
                            {
                                //print this and start over
                                Console.WriteLine("Please enter a valid option (From 1 to 4)");
                                Console.WriteLine("\nPress any key to continue ...");
                                Console.ReadKey();
                                goto adminStart;
                            }

                            opt = Convert.ToInt32(num);

                            //switch case that takes option number
                            switch (opt)
                            {
                                //case 1 update the snack price
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
                                    Console.Clear();
                                    Console.WriteLine("Updated Menu is : \n");
                                    adminUser.DisplayMenu();

                                    Console.WriteLine(" \nPress any key to go back to Admin menu");
                                    Console.ReadKey();
                                    goto adminStart;

                                    break;
                                    //case 2 update change pool 
                                case 2:
                                    (new Admin(vendingMachine)).IncreaseChangePool();
                                    Console.Clear();
                                    goto adminStart;

                                    break;
                                    //case 3 prrint total amount of money from the change pool 
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
