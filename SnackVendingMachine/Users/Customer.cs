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
            decimal sum = 0;

            Console.WriteLine("NOTE :Please Insert Coins only) \n");

            while (sum < (decimal)snackList[item - 1].GetPrice())
            {
                decimal difference = (decimal)snackList[item - 1].GetPrice() - sum;
                Console.WriteLine("Please Insert  £" + difference + "more");

                decimal newCoin = Convert.ToDecimal(Console.ReadLine());
                insertedCoins.AddRange(Enumerable.Repeat(new Coin(newCoin), 1));
                sum = insertedCoins.Sum(coin => coin.GetCoin());
            }

            if (sum > (decimal)snackList[item - 1].GetPrice())
            {
                // Give back change and snack

            }
            else
            {
                // Give back just the snack
                foreach (Coin coin in insertedCoins)
                {
                    changePool.AddRange(Enumerable.Repeat(coin, 1));
                }

                VMObj.SetCoinList(changePool);

                int newSnackQuantity = (int)snackList[item - 1].GetQuantity() - 1;
                snackList[item-1].SetQuantity(newSnackQuantity);
            }

            DisplayMenu();
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

            Console.WriteLine("1. " + snackLsit[0].GetName() + "     -- £" + snackLsit[0].GetPrice() + "  -- " + snackLsit[0].GetQuantity());
            Console.WriteLine("2. " + snackLsit[1].GetName() + " -- £" + snackLsit[1].GetPrice() + " -- " + snackLsit[1].GetQuantity());
            Console.WriteLine("3. " + snackLsit[2].GetName() + " -- £" + snackLsit[2].GetPrice() + "  -- " + snackLsit[2].GetQuantity());
            Console.WriteLine("4. " + snackLsit[3].GetName() + "  -- £" + snackLsit[3].GetPrice() + " -- " + snackLsit[3].GetQuantity());
            Console.WriteLine("5. " + snackLsit[4].GetName() + "     -- £" + snackLsit[4].GetPrice() + " -- " + snackLsit[4].GetQuantity());

            Console.WriteLine("        Please Enter Choice: ");
        }
    }
}
