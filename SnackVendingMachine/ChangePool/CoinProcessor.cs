using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal abstract class CoinProcessor
    {
        protected CoinProcessor nextProcesser;

        public void SetNextCoin(CoinProcessor processor)
        {
            this.nextProcesser = processor;
        }

        public abstract List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn);
    }
}
