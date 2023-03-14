using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal abstract class User
    {
        public User() { }

        public abstract void DisplayMenu(VendingMachine VMObj);
    }
}
