using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class TwenytyPens : CoinProcessor
    {
        List<Coin> resp;

        public override List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn)
        {
            List<Coin> coinPool = VMObj.GetCoinList();

            if (toReturn >= 0.2m)
            {
                if (coinPool.Find(coin => coin.GetCoin() == 0.20m) == null)
                {
                    resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                    return resp;
                }
                else
                {
                    if (toReturn == 0.20m)
                    {
                        Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 0.20m);
                        coinPool.Remove(toRemove);
                        toReturn = toReturn - 0.20m;
                        changeCoins.Add(toRemove);
                        VMObj.SetCoinList(coinPool);

                        return changeCoins;
                    }
                    else
                    {
                        while (toReturn > 0.20m)
                        {
                            while (toReturn > 0.20m)
                            {
                                if (coinPool.Find(coin => coin.GetCoin() == 0.20m) != null)
                                {
                                    Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 0.20m);
                                    coinPool.Remove(toRemove);
                                    toReturn = toReturn - 0.20m;
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
