using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    public class Coin
    {
        private decimal Value;

        public Coin(decimal val)
        {
            this.Value = val;
        }

        public decimal GetCoin()
        {
            return Value;
        }
    }
}
