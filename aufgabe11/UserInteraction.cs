using System;

namespace aufgabe11
{
    public class UserInteraction
    {
        public void MainMenu(Action onMangeLand,
                             Action onVisitMarket,
                             Action onEnd)
        {
            Console.WriteLine("1. Manage land\n2. Visit Market\n3. Exit Round");
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
            Console.WriteLine("1. Buy weed\n2. Sell weed\n3. Back");
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