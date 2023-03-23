using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class FivePens : CoinProcessor
    {
        public override List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn, decimal denominatior)
        {
            return base.ProcessCoin(VMObj, changeCoins, toReturn, 0.05m);
        }
    }
}
