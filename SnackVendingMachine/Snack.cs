using System;
using System.Collections.Generic;
using System.Text;

namespace SnackVendingMachine
{
    public class Snack
    {
        //attributes
        //we made the class Snack , every snack has a name,price,quantity 
        private string name;
        private double price;
        private int quantity;

        //constructor, that creates a Snack object
        public Snack(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;   
        }

        //setname method
        public void SetName(string name)
        {
            this.name = name;
        }

        //getname of a snack method
        public string GetName()
        {
            return this.name;
        }
       
        //Set price method will be used by the admin , in case of a snack needs to have its price changed
        public void SetPrice(double price) 
        {
            this.price = price;
        }

        //we are getting the price of a snack 
        public double GetPrice()
        {
            return this.price;
        }

        //sets new quantity method
        public void SetQuantity(int quantity) 
        {
            this.quantity = quantity;
        }

        //get quantity is a method that will be used to get the number of items (snacks)
        public int GetQuantity ()
        {
            return this.quantity;
        }
    }
}
