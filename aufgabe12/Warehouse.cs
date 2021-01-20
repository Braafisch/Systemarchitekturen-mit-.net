using System;
using System.Collections.Generic;

namespace aufgabe12
{
    public class Warehouse
    {
        public Dictionary<string, Good> goods;
        public Warehouse()
        {
            goods = new Dictionary<string, Good>();
        }
        public void AddGood(string goodName, int amount, int value)
        {
            var good = new Good(value: value, amount: amount);
            goods.Add(goodName, good);
        }
        public override string ToString()
        {
            var returnString = "\n          stock value\n";
            foreach (KeyValuePair<string, Good> good in goods)
            {
                returnString += String.Format("{0,10}{1,5} {2}/{3}\n", good.Key, good.Value.amount, good.Value.buyValue, good.Value.sellValue);
            }
            return returnString;
        }
    }
    public class Good
    {
        public decimal buyValue;
        public decimal sellValue;
        public int amount;
        public Good(decimal value, int amount)
        {
            this.buyValue = value;
            this.sellValue = (Math.Floor(value - value / 10));
            this.amount = amount;
        }
    }
}