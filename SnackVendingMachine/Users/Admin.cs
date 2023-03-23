using SnackVendingMachine.ChangePool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal class Admin : User
    {
        // An object of Vending Machine
        // Will be used to Get/Set Snack and Coin Pool List
        VendingMachine VMObj;

        // Constructor
        public Admin(VendingMachine obj) 
        {
            VMObj = obj;
        }

        // A Method to update the Snack Price
        // Takes Item No. as a parameter
        public void UpdateSnackPrice(int itemNo)
        {
            // Get the list of snacks
            List<Snack> snackLsit = VMObj.GetList();

            // Prompting the user to enter a new price for the snack
            Console.WriteLine("Please enter the new price for the selected Item");
            double newPrice = Convert.ToDouble(Console.ReadLine());

            // Set price of the snack
            snackLsit[itemNo-1].SetPrice(newPrice);
            VMObj.SetList(snackLsit);
        }

        // A method to Increase the quantity of coins in the Change Pool
        public void IncreaseChangePool()
        {
        retry:
            // Get the Current Change Pool and display on the screen
            List<Coin> changePool = VMObj.GetCoinList();
            Console.WriteLine("Coins already Present in the Change Pool");
            DisplayChangePool(changePool);

            // Prompting the user to choose a coin to increase its quantity
            decimal[] coins = { 2.0m, 1.0m, 0.5m, 0.20m, 0.10m, 0.05m};
            decimal coin;

            try
            {
                Console.WriteLine("\nPlease specify the coin that you want to Increase");
                coin = Convert.ToDecimal(Console.ReadLine());
                
                if(!coins.Contains(coin))
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

            // Prompting the user to add the quantity of the chosen coin
            Console.WriteLine("\nPlease specify the quantity you want to add");
            int coinQuantity = Convert.ToInt32(Console.ReadLine());

            // Adding the coin to the change Pool
            changePool.AddRange(Enumerable.Repeat(new Coin(coin), coinQuantity));
            VMObj.SetCoinList(changePool);

            // Display the updated change pool
            Console.WriteLine("\nCoins added Successfully. Updated Change Pool is: \n");
            DisplayChangePool(changePool);

            Console.Write("\nPlease press any key to continue ... ");
            Console.ReadKey();
        }

        // Method to Display the Change Pool
        public void DisplayChangePool(List<Coin> changePool)
        {
            Console.WriteLine("Coin  -- Quantity");
            Console.WriteLine("£2    -- " + changePool.Count(coin => coin.GetCoin() == 2));
            Console.WriteLine("£1    -- " + changePool.Count(coin => coin.GetCoin() == 1));
            Console.WriteLine("£0.50 -- " + changePool.Count(coin => coin.GetCoin() == 0.50m));
            Console.WriteLine("£0.20 -- " + changePool.Count(coin => coin.GetCoin() == 0.20m));
            Console.WriteLine("£0.10 -- " + changePool.Count(coin => coin.GetCoin() == 0.10m));
            Console.WriteLine("£0.05 -- " + changePool.Count(coin => coin.GetCoin() == 0.05m));
        }

        // Method to return the Total amount of money present in the Vending Machine
        public decimal GetToalAmount()
        {
            // Adding up the Value of all the coins
            List<Coin> changePool = VMObj.GetCoinList();
            return changePool.Sum(coin => coin.GetCoin());
        }

        // Method to Display the Menu 
        // This is an overriden method of the Parent Class
        public override void DisplayMenu()
        {
            List<Snack> snackLsit = VMObj.GetList();

            Console.WriteLine("Please select a snack to update its price.");
            Console.WriteLine("   Snack    -- Price -- QTY");
            Console.WriteLine("1. " + snackLsit[0].GetName() + "     -- £" + snackLsit[0].GetPrice().ToString("0.00") + " -- " + snackLsit[0].GetQuantity());
            Console.WriteLine("2. " + snackLsit[1].GetName() + " -- £" + snackLsit[1].GetPrice().ToString("0.00") + " -- " + snackLsit[1].GetQuantity());
            Console.WriteLine("3. " + snackLsit[2].GetName() + " -- £" + snackLsit[2].GetPrice().ToString("0.00") + " -- " + snackLsit[2].GetQuantity());
            Console.WriteLine("4. " + snackLsit[3].GetName() + "  -- £" + snackLsit[3].GetPrice().ToString("0.00") + " -- " + snackLsit[3].GetQuantity());
            Console.WriteLine("5. " + snackLsit[4].GetName() + "     -- £" + snackLsit[4].GetPrice().ToString("0.00") + " -- " + snackLsit[4].GetQuantity());
        }
    }
}
