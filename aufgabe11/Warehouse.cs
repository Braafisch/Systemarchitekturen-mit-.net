using System;
using System.Collections.Generic;

namespace aufgabe11
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
                returnString += String.Format("{0,10}{1,5} {2,-4}\n", good.Key, good.Value.amount, good.Value.value);
            }
            return returnString;
        }
    }
    public class Good
    {
        public decimal value;
        public int amount;
        public Good(decimal value, int amount)
        {
            this.value = value;
            this.amount = amount;
        }
    }
}