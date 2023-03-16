using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine.ChangePool
{
    internal class OnePound : CoinProcessor
    {
        List<Coin> resp;

        public override List<Coin> ProcessCoin(VendingMachine VMObj, List<Coin> changeCoins, decimal toReturn)
        {
            List<Coin> coinPool = VMObj.GetCoinList();

            if (toReturn >= 1)
            {
                if (coinPool.Find(coin => coin.GetCoin() == 1) == null)
                {
                    resp = nextProcesser.ProcessCoin(VMObj, changeCoins, toReturn);
                    return resp;
                }
                else
                {
                    if (toReturn == 1)
                    {
                        Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 1);
                        coinPool.Remove(toRemove);
                        toReturn = toReturn - 1;
                        changeCoins.Add(toRemove);
                        VMObj.SetCoinList(coinPool);

                        return changeCoins;
                    }
                    else
                    {
                        while (toReturn > 1)
                        {
                            while (toReturn > 1)
                            {
                                if (coinPool.Find(coin => coin.GetCoin() == 1) != null)
                                {
                                    Coin toRemove = coinPool.FirstOrDefault(coin => coin.GetCoin() == 1);
                                    coinPool.Remove(toRemove);
                                    toReturn = toReturn - 1;
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
