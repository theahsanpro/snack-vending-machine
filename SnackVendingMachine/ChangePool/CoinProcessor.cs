using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class CoinProcessor
    {
        protected CoinProcessor nextProcesser;

        public void SetNextCoin(CoinProcessor processor)
        {
            this.nextProcesser = processor;
        }

        public virtual List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn,decimal denominatior)
        {
            List<Coin> coinPool = VMObj.GetCoinList();
            List<Coin> resp;

            // If the value of the coin is greater or equal to 2, Proceed further
            if (toReturn >= denominatior)
            {
                // See if the coin with value £2 is not in the list, go to the next linked coin
                if (coinPool.Find(coin => coin.GetCoin() == denominatior) == null)
                {
                    resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn, denominatior);
                    return resp;
                }
                else
                {
                    // If the value of the coin is equal to £2,
                    // Remove the coin from coin pool, Add the coin to the temporary List, and decrease the amount of toReturn
                    if (toReturn == denominatior)
                    {
                        Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == denominatior);
                        coinPool.Remove(toRemove);
                        toReturn = toReturn - denominatior;
                        changeCoins.Add(toRemove);
                        VMObj.SetCoinList(coinPool);

                        return changeCoins;
                    }
                    else
                    {
                        if(denominatior == 0.05m)
                        {
                            return null;
                        }

                        while (toReturn > denominatior)
                        {
                            // if the £2 coin is present in the pool, 
                            // Remove the coin from coin pool, Add the coin to the temporary List, and decrease the amount of toReturn
                            if (coinPool.Find(coin => coin.GetCoin() == denominatior) != null)
                            {
                                Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == denominatior);
                                coinPool.Remove(toRemove);
                                toReturn = toReturn - denominatior;
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
                            resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn, denominatior);
                            return resp;
                        }
                    }
                }
            }
            // Move to the next linked coin
            else
            {
                if (denominatior == 0.05m)
                {
                    return null;
                }

                resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn, denominatior);
                return resp;
            }
        }
    }
}
