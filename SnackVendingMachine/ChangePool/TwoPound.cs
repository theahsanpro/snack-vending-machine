using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class TwoPound : CoinProcessor
    {
        // A to contain a Coin List temporarily
        List<Coin> resp;

        // Implimentation of the abstract method of the parent class
        public override List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn)
        {
            List<Coin> coinPool = VMObj.GetCoinList();

            // If the value of the coin is greater or equal to 2, Proceed further
            if (toReturn >= 2)
            {
                // See if the coin with value £2 is not in the list, go to the next linked coin
                if (coinPool.Find(coin => coin.GetCoin() == 2) == null)
                {
                    resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                    return resp;
                }
                else
                {
                    // If the value of the coin is equal to £2,
                    // Remove the coin from coin pool, Add the coin to the temporary List, and decrease the amount of toReturn
                    if (toReturn == 2)
                    {
                        Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 2);
                        coinPool.Remove(toRemove);
                        toReturn = toReturn - 2;
                        changeCoins.Add(toRemove);
                        VMObj.SetCoinList(coinPool);

                        return changeCoins;
                    }
                    else
                    {
                        while (toReturn > 2)
                        {
                            // if the £2 coin is present in the pool, 
                            // Remove the coin from coin pool, Add the coin to the temporary List, and decrease the amount of toReturn
                            if (coinPool.Find(coin => coin.GetCoin() == 2) != null)
                            {
                                Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 2);
                                coinPool.Remove(toRemove);
                                toReturn = toReturn - 2;
                                changeCoins.Add(toRemove);
                            }
                            else
                            {
                                break;
                            }
                        }

                        // if there is no amount to be retured, update the coin pool and return
                        if (toReturn == 0)
                        {
                            VMObj.SetCoinList(coinPool);
                            return changeCoins;
                        }
                        else
                        {
                            resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                            return resp;
                        }
                    }
                }
            }
            // Move to the next linked coin
            else
            {
                resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                return resp;
            }
        }
    }
}
