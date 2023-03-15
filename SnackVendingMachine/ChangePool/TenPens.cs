using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class TenPens : CoinProcessor
    {
        public override void ProcessCoin(Coin coin)
        {
            if (coin.GetCoin() == .10m)
            {
                Console.WriteLine("Ten Pens Inserted");
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
