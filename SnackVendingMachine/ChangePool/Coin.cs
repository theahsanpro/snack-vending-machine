using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    // Thsis class will be used to represent a coin
    public class Coin
    {
        // Value of the coin
        private decimal Value;

        public Coin(decimal val)
        {
            this.Value = val;
        }

        // Get method to get the value of a coin
        public decimal GetCoin()
        {
            return Value;
        }
    }
}
