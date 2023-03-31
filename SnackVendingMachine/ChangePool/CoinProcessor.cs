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

            if (toReturn >= denominatior)
            {
                if (coinPool.Find(coin => coin.GetCoin() == denominatior) == null)
                {
                    resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn, denominatior);
                    return resp;
                }
                else
                {
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
