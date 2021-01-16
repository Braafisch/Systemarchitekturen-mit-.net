using System;

namespace aufgabe11
{
    public class Possession
    {
        public decimal money;
        public int land;
        public Warehouse warehouse;
        public decimal landValue = 50;
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
            return "Money: " + money.ToString() + " | " + "Land: " + land.ToString() + warehouse.ToString();
        }
    }
    public class PossessionLogic
    {
        public void Sell(int count, Possession possession)
        {
            if (possession.purchasedLand - (possession.soldLand + count) >= 0)
            {
                possession.soldLand += count;
                possession.land -= count;
                possession.money += (Math.Floor(possession.landValue - possession.landValue / 10)) * count;
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
            if (possession.money - cost > 0)
            {
                possession.money -= cost;
                possession.warehouse.weed += count;
            }
            else
            {
                throw new InvalidOperationException("Not enough equity!");
            }
        }
        public void SellWeed(int count, Possession possession)
        {
            if (possession.warehouse.weed - count > 0)
            {
                possession.money += (Math.Floor(possession.warehouse.weedValue - possession.warehouse.weedValue / 10)) * count;
                possession.warehouse.weed -= count;
            }
            else
            {
                throw new InvalidOperationException("Not enough weed!");
            }
        }
        public void BuyOil(int count, Possession possession)
        {
            var cost = possession.warehouse.oilValue * count;
            if (possession.money - cost > 0)
            {
                possession.money -= cost;
                possession.warehouse.oil += count;
            }
            else
            {
                throw new InvalidOperationException("Not enough equity!");
            }
        }
        public void SellOil(int count, Possession possession)
        {
            if (possession.warehouse.oil - count > 0)
            {
                possession.money += (Math.Floor(possession.warehouse.oilValue - possession.warehouse.oilValue / 10)) * count;
                possession.warehouse.oil -= count;
            }
            else
            {
                throw new InvalidOperationException("Not enough weed!");
            }
        }
    }
}