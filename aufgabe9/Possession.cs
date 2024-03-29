using System;

namespace aufgabe9
{
    public class Possession
    {
        public int money;
        public int land;
        public int landValue = 50;
        public int purchased;
        public int sold;
        public Possession(int money)
        {
            this.land = 0;
            this.money = money;
            this.purchased = 0;
            this.sold = 0;
        }
        public override string ToString()
        {
            return "Money: " + money.ToString() + " | " + "Land: " + land.ToString();
        }
    }
    public class PossessionLogic
    {
        public void Sell(int count, Possession possession)
        {
            if (possession.purchased - (possession.sold + count) >= 0)
            {
                possession.sold += count;
                possession.land -= count;
                possession.money += (possession.landValue - possession.landValue / 10) * count;
            }
            else
            {
                throw new InvalidOperationException("Not enough properties!");
            }
        }
        public void Buy(int count, Possession possession)
        {
            if (possession.money - count * possession.landValue >= 0)
            {
                possession.purchased += count;
                possession.land += count;
                possession.money -= possession.landValue * count;
            }
            else 
            {
                throw new InvalidOperationException("Not enough equity!");
            }
        }
    }
}