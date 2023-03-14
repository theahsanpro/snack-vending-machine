using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine
{
    internal class VendingMachine
    {
        public Snack snack;
        private List<Snack> snackLsit = new List<Snack>();

        public VendingMachine()
        {
            InitianlizeVendingMachine();
        }

        public List<Snack> GetList()
        {
            return snackLsit;
        }

        public void SetList(List<Snack> list)
        {
            snackLsit = list;
        }


        public void InitianlizeVendingMachine()
        {
            snackLsit.Add(new Snack("Cola", 1.50, 10));
            snackLsit.Add(new Snack("Choc Bar", 1.25, 10));
            snackLsit.Add(new Snack("Skittles", 1.70, 8));
            snackLsit.Add(new Snack("Bikkies", 1.25, 10));
            snackLsit.Add(new Snack("Gala", 1.25, 4));
        }


    }
}
