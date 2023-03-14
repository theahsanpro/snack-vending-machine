using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal class Admin : User
    {
        public Admin() { }

        public void UpdateSnackPrice(VendingMachine VMObj, int itemNo)
        {
            List<Snack> snackLsit = VMObj.GetList();

            Console.WriteLine("Please enter the new price for the selected Item");
            double newPrice = Convert.ToInt32(Console.ReadLine());

            snackLsit[itemNo-1].SetPrice(newPrice);
            VMObj.SetList(snackLsit);
        }

        public override void DisplayMenu(VendingMachine VMObj)
        {
            List<Snack> snackLsit = VMObj.GetList();

            Console.WriteLine("Please select a snack to update its price.");
            Console.WriteLine("   Snack    -- Price -- QTY");

            Console.WriteLine("1. " + snackLsit[0].GetName() + "     -- £" + snackLsit[0].GetPrice() + "  -- " + snackLsit[0].GetQuantity());
            Console.WriteLine("2. " + snackLsit[1].GetName() + " -- £" + snackLsit[1].GetPrice() + " -- " + snackLsit[1].GetQuantity());
            Console.WriteLine("3. " + snackLsit[2].GetName() + " -- £" + snackLsit[2].GetPrice() + "  -- " + snackLsit[2].GetQuantity());
            Console.WriteLine("4. " + snackLsit[3].GetName() + "  -- £" + snackLsit[3].GetPrice() + " -- " + snackLsit[3].GetQuantity());
            Console.WriteLine("5. " + snackLsit[4].GetName() + "     -- £" + snackLsit[4].GetPrice() + " -- " + snackLsit[4].GetQuantity());
        }
    }
}
