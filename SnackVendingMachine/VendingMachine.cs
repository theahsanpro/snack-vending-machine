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

        // List for Snacks and ChangePool
        private List<Snack> snackLsit = new List<Snack>();
        private List<Coin> changePool = new List<Coin>();

        // Constructor
        // Vending Machine Snack List and Change Pool are initialized in the Constructor
        public VendingMachine()
        {
            InitianlizeVendingMachine();
            InitializeChangePool();
            Console.WriteLine("Test");
        }

        // Get List method to get the Snack List
        public List<Snack> GetList()
        {
            return snackLsit;
        }

        // Set List method to set the Snack List
        public void SetList(List<Snack> list)
        {
            this.snackLsit = list;
        }

        // Get method to get the Change Pool
        public List<Coin> GetCoinList() 
        {
            return changePool;
        }

        // SEt method to set the Change Pool
        public void SetCoinList(List<Coin> list)
        {
            changePool = list;
        }

        // This method Initializes the Snack List when the object of this class is created
        public void InitianlizeVendingMachine()
        {
            snackLsit.Add(new Snack("Cola", 1.50, 10));
            snackLsit.Add(new Snack("Choc Bar", 1.25, 10));
            snackLsit.Add(new Snack("Skittles", 1.70, 8));
            snackLsit.Add(new Snack("Bikkies", 1.25, 10));
            snackLsit.Add(new Snack("Gala", 1.25, 4));
        }

        // This method Initializes the Change Pool when the object of this class is created
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
