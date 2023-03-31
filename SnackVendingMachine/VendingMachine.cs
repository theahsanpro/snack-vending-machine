using SnackVendingMachine.ChangePool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackVendingMachine
{
    internal class VendingMachine
    {
        public Snack snack;

        private List<Snack> snackLsit = new List<Snack>();
        private List<Coin> changePool = new List<Coin>();

        public VendingMachine()
        {
            InitianlizeVendingMachine();
            InitializeChangePool();
            Console.WriteLine("Test");
        }

        public List<Snack> GetList()
        {
            return snackLsit;
        }

        public void SetList(List<Snack> list)
        {
            this.snackLsit = list;
        }

        public List<Coin> GetCoinList() 
        {
            return changePool;
        }

        public void SetCoinList(List<Coin> list)
        {
            changePool = list;
        }

        public void InitianlizeVendingMachine()
        {
            snackLsit.Add(new Snack("Cola", 1.50, 10));
            snackLsit.Add(new Snack("Choc Bar", 1.25, 10));
            snackLsit.Add(new Snack("Skittles", 1.70, 8));
            snackLsit.Add(new Snack("Bikkies", 1.25, 10));
            snackLsit.Add(new Snack("Gala", 1.25, 4));
        }

        public void InitializeChangePool()
        {
            changePool.AddRange(Enumerable.Repeat(new Coin(2), 2));
            changePool.AddRange(Enumerable.Repeat(new Coin(1), 3));
            changePool.AddRange(Enumerable.Repeat(new Coin(0.50m), 4));
            changePool.AddRange(Enumerable.Repeat(new Coin(0.20m), 5));
            changePool.AddRange(Enumerable.Repeat(new Coin(0.10m), 10));
            changePool.AddRange(Enumerable.Repeat(new Coin(0.05m), 20));
        }


    }
}
