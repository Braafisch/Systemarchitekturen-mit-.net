using System;

namespace aufgabe9
{
    public class Possession
    {
        public int money;
        public int land;
        public Warehouse warehouse;
        public int landValue = 50;
        public int purchasedLand;
        public int soldLand;
        public Possession(int money, int land, Warehouse warehouse)
        {
            this.land = land;
            this.money = money;
            this.warehouse = warehouse;
            this.purchasedLand = 0;
            this.soldLand = 0;
        }
        public override string ToString()
        {
            return "Money: " + money.ToString() + " | " + "Land: " + land.ToString();
        }
    }
    public class PossessionLogic
    {
        public void SellLand(int count, Possession possession)
        {
            if (possession.purchasedLand - (possession.soldLand + count) >= 0)
            {
                possession.soldLand += count;
                possession.land -= count;
                possession.money += (possession.landValue - possession.landValue / 10) * count;
            }
            else
            {
                throw new InvalidOperationException("Not enough properties!");
            }
        }
        public void BuyLand(int count, Possession possession)
        {
            if (possession.money - count * possession.landValue >= 0)
            {
                possession.purchasedLand += count;
                possession.land += count;
                possession.money -= possession.landValue * count;
            }
            else 
            {
                throw new InvalidOperationException("Not enough equity!");
            }
        }
        public void BuyWeed(int count, Possession possession)
        {
            var cost = possession.warehouse.weedValue * count;
            if (money - cost > 0)
            {
                money -= cost;
                possession.warehouse.weed += count;
            }
        }
    }
}