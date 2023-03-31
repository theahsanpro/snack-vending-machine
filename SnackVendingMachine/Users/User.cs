using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.Users
{
    internal abstract class User
    {
        public User() 
        {

        }

        // Abstract method
        public abstract void DisplayMenu();
    }
}
