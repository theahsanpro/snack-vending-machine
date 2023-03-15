using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class TwoPound : CoinProcessor
    {
        public override void ProcessCoin(Coin coin)
        {
            if (coin.GetCoin() == 2)
            {
                Console.WriteLine("Two Ponds Inserted");
            }
            else if(nextProcesser != null) 
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
