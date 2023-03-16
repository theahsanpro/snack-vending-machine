using SnackVendingMachine.ChangePool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal class Admin : User
    {
        VendingMachine VMObj;

        public Admin(VendingMachine obj) 
        {
            VMObj = obj;
        }

        public void UpdateSnackPrice(int itemNo)
        {
            List<Snack> snackLsit = VMObj.GetList();

            Console.WriteLine("Please enter the new price for the selected Item");
            double newPrice = Convert.ToInt32(Console.ReadLine());

            snackLsit[itemNo-1].SetPrice(newPrice);
            VMObj.SetList(snackLsit);
        }

        public void IncreaseChangePool()
        {
            List<Coin> changePool = VMObj.GetCoinList();
            Console.WriteLine("Coins already Present in the Change Pool");
            DisplayChangePool(changePool);

            Console.WriteLine("\nPlease specify the coin that you want to Increase");
            decimal coin = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("\nPlease specify the quantity you want to add");
            int coinQuantity = Convert.ToInt32(Console.ReadLine());

            changePool.AddRange(Enumerable.Repeat(new Coin(coin), coinQuantity));
            VMObj.SetCoinList(changePool);

            Console.WriteLine("\nCoins added Successfully. Updated Change Pool is: \n");
            DisplayChangePool(changePool);

            Console.Write("\nPlease press any key to continue ... ");
            Console.ReadKey();
        }

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

        public decimal GetToalAmount()
        {
            List<Coin> changePool = VMObj.GetCoinList();
            return changePool.Sum(coin => coin.GetCoin());
        }

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
