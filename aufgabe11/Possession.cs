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
        public void SellLand(int count, Possession possession)
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
        public void BuyGoods(int count, string goodName, Possession possession)
        {
            var good = possession.warehouse.goods[goodName];
            var cost = good.value * count;
            if (possession.money - cost > 0)
            {
                possession.money -= cost;
                good.amount += count;
            }
            else
            {
                throw new InvalidOperationException("Not enough equity!");
            }
        }
        public void SellGoods(int count, string goodName, Possession possession)
        {
            var good = possession.warehouse.goods[goodName];
            if (good.amount - count > 0)
            {
                possession.money += (Math.Floor(good.value - good.value / 10)) * count;
                good.amount -= count;
            }
            else
            {
                throw new InvalidOperationException("Not enough goods!");
            }
        }
    }
}