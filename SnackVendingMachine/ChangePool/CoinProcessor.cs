using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal abstract class CoinProcessor
    {
        // Object od the same class
        // Used to impliment the chain of Responisbility
        protected CoinProcessor nextProcesser;

        // Method to link all the coins
        public void SetNextCoin(CoinProcessor processor)
        {
            this.nextProcesser = processor;
        }

        // Abstract method - Implimented by all the child classes
        public abstract List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn);
    }
}
