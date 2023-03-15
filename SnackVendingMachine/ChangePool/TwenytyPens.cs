using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class TwenytyPens : CoinProcessor
    {
        public override void ProcessCoin(Coin coin)
        {
            if (coin.GetCoin() == 0.20m)
            {
                Console.WriteLine("Twenty Pens Inserted");
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
