using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine
{
    public class Snack
    {
        private string name;
        private double price;
        private float quantity;

        public Snack(string name, double price, float quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;   
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
        
        public void SetPrice(double price) 
        {
            this.price = price;
        }

        public double GetPrice()
        {
            return this.price;
        }

        public void SetQuantity(float quantity) 
        {
            this.quantity = quantity;
        }

        public float GetQuantity ()
        {
            return this.quantity;
        }
    }
}
