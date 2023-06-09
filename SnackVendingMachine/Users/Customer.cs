﻿using Microsoft.VisualBasic.FileIO;
using SnackVendingMachine.ChangePool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal class Customer : User
    {
        VendingMachine VMObj;

        public Customer(VendingMachine obj)
        {
            VMObj = obj;
        }

        public void MakePurchase(int item)
        {
            List<Snack> snackList = VMObj.GetList();
            List<Coin> changePool = VMObj.GetCoinList();
            List<Coin> insertedCoins = new List<Coin>();
            List<Coin> changeCoins = new List<Coin>();

            decimal[] coinArray = { 2.0m, 1.0m, 0.5m, 0.2m, 0.1m, 0.05m };
            decimal sum = 0;

            if (snackList[item - 1].GetQuantity() <= 0)
            {
                Console.WriteLine("\nThis Item is out of stock. Please Select another Item.\n");
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
            else
            {
            retry:
                Console.WriteLine("\n(NOTE: Please Insert Coins only)");

                while (sum < (decimal)snackList[item - 1].GetPrice())
                {
                    decimal difference = (decimal)snackList[item - 1].GetPrice() - sum;
                    Console.WriteLine("\nPlease Insert: £" + difference + " or press 'C' to cancel the transaction");

                    var number = Console.ReadLine();
                    decimal newCoin;

                    bool isNumber = decimal.TryParse(number, out newCoin);

                    if (!isNumber)
                    {
                        if (number.ToLower() == "c")
                        {
                            Console.Write("\nThe Transaaction has been declined. Please collect your change: [ ");

                            foreach (Coin coin in insertedCoins)
                            {
                                Console.Write(coin.GetCoin() + " ");
                            }
                            Console.Write("]");

                            Console.WriteLine("\nPress any key to continue ...");
                            Console.ReadKey();

                            return;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option (From 1 to 5)");
                            Console.WriteLine("\nPress any key to continue ...");
                            Console.ReadKey();
                            goto retry;

                        }
                    }

                enterAgain:

                    try
                    {
                        if (coinArray.Contains(newCoin))
                        {
                            insertedCoins.AddRange(Enumerable.Repeat(new Coin(newCoin), 1));
                            sum = insertedCoins.Sum(coin => coin.GetCoin());
                        }
                        else
                        {
                            Console.WriteLine("Please Enter a valid coin (£2, £1, £0.5, £0.2, £0.1, £0.05)");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please Enter a Valid Coin");
                        goto enterAgain;
                    }

                }

                if (sum > (decimal)snackList[item - 1].GetPrice())
                {
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

                    decimal changeToReturn = sum - (decimal)snackList[item - 1].GetPrice();

                    List<Coin> response = twoPound.ProcessCoin(VMObj, changeCoins, changeToReturn, 2.0m);

                    if (response == null)
                    {
                        Console.WriteLine("Transaction Declined due to Insufficient coins in the machine. \n");

                        Console.Write("Please Collect the Coins you Inserted: [ ");
                        foreach (Coin coin in insertedCoins)
                        {
                            Console.Write(coin.GetCoin() + " ");
                        }
                        Console.Write("]");

                        Console.WriteLine("\nPress any key to continue ...");
                        Console.ReadKey();
                    }
                    else
                    {
                        foreach (Coin coin in insertedCoins)
                        {
                            changePool.AddRange(Enumerable.Repeat(coin, 1));
                        }

                        snackList[item - 1].SetQuantity(snackList[item - 1].GetQuantity() - 1);

                        Console.WriteLine("\nPlease Collect Your Product: " + snackList[item - 1].GetName());
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
                    foreach (Coin coin in insertedCoins)
                    {
                        changePool.AddRange(Enumerable.Repeat(coin, 1));
                    }

                    VMObj.SetCoinList(changePool);

                    int newSnackQuantity = (int)snackList[item - 1].GetQuantity() - 1;
                    snackList[item - 1].SetQuantity(newSnackQuantity);

                    Console.WriteLine("\nPlease Collect Your Product: " + snackList[item - 1].GetName());

                    Console.WriteLine("\nPress any key to continue ...");
                    Console.ReadKey();
                }

            }
        }

        public override void DisplayMenu()
        {
            int sno = 1;
            List<Snack> snackLsit = VMObj.GetList();

            Console.WriteLine("########################################");
            Console.WriteLine(" #     Mechachrome Vending Machin     #");
            Console.WriteLine("  #       Hawking Edible Wares       #");
            Console.WriteLine("   ##################################");
            Console.WriteLine("   Snack    -- Price -- QTY");

            Console.WriteLine("1. " + snackLsit[0].GetName() + "     -- £" + snackLsit[0].GetPrice().ToString("0.00") + "  -- " + snackLsit[0].GetQuantity());
            Console.WriteLine("2. " + snackLsit[1].GetName() + " -- £" + snackLsit[1].GetPrice().ToString("0.00") + " -- " + snackLsit[1].GetQuantity());
            Console.WriteLine("3. " + snackLsit[2].GetName() + " -- £" + snackLsit[2].GetPrice().ToString("0.00") + "  -- " + snackLsit[2].GetQuantity());
            Console.WriteLine("4. " + snackLsit[3].GetName() + "  -- £" + snackLsit[3].GetPrice().ToString("0.00") + " -- " + snackLsit[3].GetQuantity());
            Console.WriteLine("5. " + snackLsit[4].GetName() + "     -- £" + snackLsit[4].GetPrice().ToString("0.00") + " -- " + snackLsit[4].GetQuantity());

            Console.WriteLine("        Please Enter Choice: ");
        }
    }
}
