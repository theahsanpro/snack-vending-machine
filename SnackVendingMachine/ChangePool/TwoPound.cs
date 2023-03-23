using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class TwoPound : CoinProcessor
    {
        public TwoPound()
        {
            
        }

        public override List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn, decimal denominatior)
        {
            return base.ProcessCoin(VMObj, changeCoins, toReturn, 2.0m);
        }
    }
}
