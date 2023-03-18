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
        // This method is overridden by the child class
        public abstract void DisplayMenu();
    }
}
