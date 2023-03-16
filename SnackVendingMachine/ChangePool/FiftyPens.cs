using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class FiftyPens : CoinProcessor
    {
        List<Coin> resp;

        public override List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn)
        {
            List<Coin> coinPool = VMObj.GetCoinList();

            if (toReturn >= 0.5m)
            {
                if (coinPool.Find(coin => coin.GetCoin() == 0.5m) == null)
                {
                    resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                    return resp;
                }
                else
                {
                    if (toReturn == 0.5m)
                    {
                        Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 0.5m);
                        coinPool.Remove(toRemove);
                        toReturn = toReturn - 0.5m;
                        changeCoins.Add(toRemove);
                        VMObj.SetCoinList(coinPool);

                        return changeCoins;
                    }
                    else
                    {
                        while (toReturn > 0.50m)
                        {
                            while (toReturn > 0.50m)
                            {
                                if (coinPool.Find(coin => coin.GetCoin() == 0.50m) != null)
                                {
                                    Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 0.50m);
                                    coinPool.Remove(toRemove);
                                    toReturn = toReturn - 0.50m;
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
                                resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                                return resp;
                            }
                        }

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
            else
            {
                resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                return resp;
            }
        }
    }
}
