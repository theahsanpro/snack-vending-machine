using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class FivePens : CoinProcessor
    {
        public override void ProcessCoin(Coin coin)
        {
            if (coin.GetCoin() == 0.05m)
            {
                Console.WriteLine("Five Pens Inserted");
            }
            else if (nextProcesser != null)
            {
                nextProcesser.ProcessCoin(coin);
            }
            else
            {
                Console.WriteLine("Invalid Coin");
            }
        }
    }
}
