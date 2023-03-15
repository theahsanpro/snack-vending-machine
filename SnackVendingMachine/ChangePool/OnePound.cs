using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class OnePound : CoinProcessor
    {
        public override void ProcessCoin(Coin coin)
        {
            if (coin.GetCoin() == 1)
            {
                Console.WriteLine("One Pond Inserted");
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
