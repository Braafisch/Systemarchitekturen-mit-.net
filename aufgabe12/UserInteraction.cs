using System;
using System.Linq;

namespace aufgabe12
{
    public class UserInteraction
    {
        private void WriteGoodsOptions(string[] goods)
        {
            for(var i = 0; i < goods.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, goods[i]); 
            }
            Console.WriteLine("{0}. Abort", (goods.Length));
        }
        public void MainMenu(Action onMangeLand,
                             Action onVisitMarket,
                             Action onEnd)
        {
            Console.WriteLine("1. Manage land\n2. Visit market\n3. Exit Round");
            switch (Console.ReadLine())
            {
                case "1":
                    onMangeLand();
                    break;
                case "2":
                    onVisitMarket();
                    break;
                case "3":
                    onEnd();
                    break;
                default:
                    Console.Error.WriteLine("Wrong Input!");
                    break;
            }
        }
        public void ManageLandMenu(Action onBuy,
                                   Action onSell,
                                   Action onBack)
        {
            Console.WriteLine("1. Buy land\n2. Sell land\n3. Back");
            switch (Console.ReadLine())
            {
                case "1":
                    onBuy();
                    break;
                case "2":
                    onSell();
                    break;
                case "3":
                    onBack();
                    break;
                default:
                    Console.Error.WriteLine("Wrong Input!");
                    break;
            }
        }
        public void ManageMarketMenu(Action onBuy,
                                     Action onSell,
                                     Action onBack)
        {
            Console.WriteLine("1. Buy goods\n2. Sell goods\n3. Back");
            switch (Console.ReadLine())
            {
                case "1":
                    onBuy();
                    break;
                case "2":
                    onSell();
                    break;
                case "3":
                    onBack();
                    break;
                default:
                    Console.Error.WriteLine("Wrong Input!");
                    break;
            }
        }
        public void ManageBuyGoodsMenu(Warehouse warehouse,
                                       Action<string> onGood,
                                       Action onAbort)
        {
            Console.WriteLine("Which goods you want to buy?");
            var goods = warehouse.goods.Keys.ToArray();
            WriteGoodsOptions(goods: goods);
            var select = int.Parse(Console.ReadLine());
            if(select < goods.Length)
            {
                onGood(goods[select]);
            }
            else
            {
                onAbort();
            }
        }
        public void ManageSellGoodsMenu(Warehouse warehouse,
                                        Action<string> onGood,
                                        Action onAbort)
        {
            Console.WriteLine("Which goods you want to sell?");
            var goods = warehouse.goods.Keys.ToArray();
            WriteGoodsOptions(goods: goods);
            var select = int.Parse(Console.ReadLine());
            if(select < goods.Length)
            {
                onGood(goods[select]);
            }
            else
            {
                onAbort();
            }
        }
        public int AmountToSell()
        {
            Console.WriteLine("How much should be sold?");
            return int.Parse(Console.ReadLine());
        }
        public int AmountToBuy()
        {
            Console.WriteLine("How much should be purchase?");
            return int.Parse(Console.ReadLine());
        }
        public void PrintErr()
        {
            Console.Error.WriteLine("You can Buy/Sell this amount Land");
        }
    }
}