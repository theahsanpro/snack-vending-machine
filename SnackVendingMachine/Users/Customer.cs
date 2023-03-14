using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal class Customer : User
    {
        public Customer()
        {
                
        }

        public override void DisplayMenu(VendingMachine VMObj)
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
