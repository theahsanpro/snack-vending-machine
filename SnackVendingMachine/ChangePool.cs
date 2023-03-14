using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SnackVendingMachine
{
	public class ChangePool
	{
        Dictionary<double, int> changePool = new Dictionary<double, int>();

        public ChangePool()
		{
            InitializeChangepool();
		}

        public double GetTotalAmount()
        {
            double totalAmount = 0;

            foreach (KeyValuePair<double, int> coin in changePool)
            {
                double val = Convert.ToDouble(coin.Value);
                totalAmount += coin.Key * val;
            }

            return totalAmount;
        }

        public void InitializeChangepool()
        {
            changePool[2.0] = 2;
            changePool[1.0] = 3;
            changePool[0.50] = 4;
            changePool[0.20] = 5;
            changePool[0.10] = 10;
            changePool[0.05] = 20;
        }
    }
}

