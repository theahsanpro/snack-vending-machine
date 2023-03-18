using SnackVendingMachine.ChangePool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal class Customer : User
    {
        // An object of Vending Machine
        // Will be used to Get/Set Snack and Coin Pool List
        VendingMachine VMObj;

        //constructor of customer takes an vending machine obj and passes it into the vanding machine 
        //we have two lists in the vending machine class 
        //by doing this to the constructor , we can access the lists from the other class
        public Customer(VendingMachine obj)
        {
            VMObj = obj;
        }

        //a method that helps the customer to make a purchase from the vending machine
        //for this to happen:
        public void MakePurchase(int item)
        {
            //we need to take the list of items from the snack list
            List<Snack> snackList = VMObj.GetList();
            //as well as from the changepool list
            List<Coin> changePool = VMObj.GetCoinList();
            //these two lists are been made to handle the coins to be inserted in the changepool and the coins that come off the 
            //change pool and needs to be given back to the customer
            List<Coin> insertedCoins = new List<Coin>();
            List<Coin> changeCoins = new List<Coin>();

            //this is an array of all the coin values that are in the coin list and can be used , either inserted from customer or 
            //given back as change
            decimal[] coinArray = { 2.0m, 1.0m, 0.5m, 0.2m, 0.1m, 0.05m };
            decimal sum = 0;

            //here we are checking by getting the quantity number of the snack if is 0
            if (snackList[item - 1].GetQuantity() <= 0)
            {
                //it prints this message
                Console.WriteLine("\nThis Item is out of stock. Please Select another Item.\n");
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
            else
            {
                //prompts the user to insert coins
                Console.WriteLine("\n(NOTE: Please Insert Coins only)");

                //while the sum of the coins the user(customer) have inserted are less from the price of the item do this
                while (sum < (decimal)snackList[item - 1].GetPrice())
                {
                    //find the difference between the two numbers , which is the number that the user has to give more to get the item
                    decimal difference = (decimal)snackList[item - 1].GetPrice() - sum;
                    //print that difference
                    Console.WriteLine("\nPlease Insert: £" + difference);

                    enterAgain:

                    try
                    {
                        //if the number he insertes is the correct number
                        decimal newCoin = Convert.ToDecimal(Console.ReadLine());
                        //if correct number we adding this to the list
                        if (coinArray.Contains(newCoin))
                        {
                            insertedCoins.AddRange(Enumerable.Repeat(new Coin(newCoin), 1));
                            sum = insertedCoins.Sum(coin => coin.GetCoin());
                        }
                        else
                        {
                            //else enter the correct number
                            Console.WriteLine("Please Enter a valid coin (£2, £1, £0.5, £0.2, £0.1, £0.05)");
                        }
                    }
                    catch
                    {
                        //if invalid input start again
                        Console.WriteLine("Please Enter a Valid Coin");
                        goto enterAgain;
                    }

                }

                //if the sum of the money the user is providing are more than the price of the item
                if (sum > (decimal)snackList[item - 1].GetPrice())
                {
                    // Give back change and snack
                    CoinProcessor twoPound = new TwoPound();
                    CoinProcessor onePound = new OnePound();
                    CoinProcessor fiftyPens = new FiftyPens();
                    CoinProcessor twentyPens = new TwenytyPens();
                    CoinProcessor tenPens = new TenPens();
                    CoinProcessor fivePens = new FivePens();

                    twoPound.SetNextCoin(onePound);
                    onePound.SetNextCoin(fiftyPens);
                    fiftyPens.SetNextCoin(twentyPens);
                    twentyPens.SetNextCoin(tenPens);
                    tenPens.SetNextCoin(fivePens);

                    //find the difference and get the coins from the coin pool to return them back to the customer
                    decimal changeToReturn = sum - (decimal)snackList[item - 1].GetPrice();

                    List<Coin> response = twoPound.ProcessCoin(VMObj, changeCoins, changeToReturn);

                    //if there are not enough coins in the pool , cancel transaction , and provide back all the money
                    if (response == null)
                    {
                        Console.WriteLine("Transaction Declined due to Insufficient coins in the machine. \n");

                        Console.WriteLine("Please Collect the Coins you Inserted: [ ");
                        foreach (Coin coin in insertedCoins)
                        {
                            Console.Write(coin.GetCoin()+" ");
                        }
                        Console.Write("]");

                        Console.WriteLine("\nPress any key to continue ...");
                        Console.ReadKey();
                    }
                    else
                    {
                        //if all good add them to pool 
                        foreach (Coin coin in insertedCoins)
                        {
                            changePool.AddRange(Enumerable.Repeat(coin, 1));
                        }

                        // Lower snack quantity
                        snackList[item - 1].SetQuantity(snackList[item - 1].GetQuantity() - 1);

                        //Display result/ bakc change
                        Console.Clear();
                        Console.WriteLine("Please Collect Your Product: " + snackList[item - 1].GetName());
                        Console.Write("\nPlease Collect the Change: [ ");
                        foreach (Coin coin in response)
                        {
                            Console.Write(coin.GetCoin() + " ");
                        }
                        Console.Write("]");

                        Console.WriteLine("\nPress any key to continue ...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    //if number is correct 
                    // Give back just the snack
                    foreach (Coin coin in insertedCoins)
                    {
                        changePool.AddRange(Enumerable.Repeat(coin, 1));
                    }

                    VMObj.SetCoinList(changePool);

                    int newSnackQuantity = (int)snackList[item - 1].GetQuantity() - 1;
                    snackList[item - 1].SetQuantity(newSnackQuantity);

                    Console.Clear();
                    Console.WriteLine("Please Collect Your Product: " + snackList[item - 1].GetName());

                    Console.WriteLine("\nPress any key to continue ...");
                    Console.ReadKey();
                }

            }
        }

        //overriden method from the user parent class 
        public override void DisplayMenu()
        {
            int sno = 1;
            List<Snack> snackLsit = VMObj.GetList();

            Console.WriteLine("########################################");
            Console.WriteLine(" #     Mechachrome Vending Machin     #");
            Console.WriteLine("  #       Hawking Edible Wares       #");
            Console.WriteLine("   ##################################");
            Console.WriteLine("   Snack    -- Price -- QTY");

            Console.WriteLine("1. " + snackLsit[0].GetName() + "     -- £" + snackLsit[0].GetPrice() + "  -- " + snackLsit[0].GetQuantity());
            Console.WriteLine("2. " + snackLsit[1].GetName() + " -- £" + snackLsit[1].GetPrice() + " -- " + snackLsit[1].GetQuantity());
            Console.WriteLine("3. " + snackLsit[2].GetName() + " -- £" + snackLsit[2].GetPrice() + "  -- " + snackLsit[2].GetQuantity());
            Console.WriteLine("4. " + snackLsit[3].GetName() + "  -- £" + snackLsit[3].GetPrice() + " -- " + snackLsit[3].GetQuantity());
            Console.WriteLine("5. " + snackLsit[4].GetName() + "     -- £" + snackLsit[4].GetPrice() + " -- " + snackLsit[4].GetQuantity());

            Console.WriteLine("        Please Enter Choice: ");
        }
    }
}
