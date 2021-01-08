using System;

namespace aufgabe9
{
    public class Possession
    {
        public int money;
        public int land;
        private const int landValue = 50;
        private int purchased;
        private int sold;
        public Possession(int money)
        {
            this.land = 0;
            this.money = money;
            this.purchased = 0;
            this.sold = 0;
        }
        public void approvePurchase(int count,
                                    Action<int> onApprove,
                                    Action onNotApprove)
        {
            if (this.money - count * landValue >= 0)
                onApprove(count);
            else
                onNotApprove();
        }
        public void approveSell(int count,
                                Action<int> onApprove,
                                Action onNotApprove)
        {
            if (purchased - (sold + count) > 0)
                onApprove(count);
            else
                onNotApprove();
        }
        public void Sell(int count)
        {
            this.sold++;
            this.land -= count;
            this.money += (landValue - landValue / 10) * count;
        }
        public void Buy(int count)
        {
            this.purchased++;
            this.land += count;
            this.money -= landValue * count;
        }
        public override string ToString()
        {
            return "Geld: " + money.ToString() + " | " + "Land: " + land.ToString();
        }
    }

}