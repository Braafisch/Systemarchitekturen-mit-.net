using System;

namespace aufgabe11
{
    public class Warehouse
    {
        public int weed;
        public decimal weedValue = 25;
        public int oil;
        public decimal oilValue = 50;
        public int metal;
        public decimal metalValue = 60;
        public int christall;
        public decimal christallValue = 75;
        public Warehouse(int weed, int oil, int metal, int christall)
        {
            this.weed = weed;
            this.oil = oil;
            this.metal = metal;
            this.christall = christall;
        }
        public override string ToString()
        {
            return String.Format("\n    stock   Value\nweed {0}      {1}\noil {2}      {3}\nmetal {4}      {5}\nchristall {6}      {7}", weed, weedValue, oil, oilValue, metal, metalValue, christall, christallValue);
        }
    }
}