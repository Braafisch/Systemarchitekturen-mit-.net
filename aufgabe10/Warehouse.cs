using System;

namespace aufgabe10
{
    public class Warehouse
    {
        public int weed;
        public decimal weedValue = 25;
        public Warehouse(int weed) => this.weed = weed;
        public override string ToString()
        {
            return String.Format("\n    stock   Value\nweed {0}      {1}", weed, weedValue);
        }
    }
}