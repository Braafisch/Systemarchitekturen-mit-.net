using System;

namespace aufgabe9
{
    public class UserInteraction
    {
        public void MainMenu(Action onMangeLand,
                             Action onEnd)
        {
            Console.WriteLine("1. Manage land\n2. Exit Round");
            switch (Console.ReadLine())
            {
                case "1":
                    onMangeLand();
                    break;
                case "2":
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
        public int Sell()
        {
            Console.WriteLine("How much land should be sold?");
            return int.Parse(Console.ReadLine());
        }
        public int Buy()
        {
            Console.WriteLine("How much land to purchase?");
            return int.Parse(Console.ReadLine());
        }
        public void PrintErr()
        {
            Console.Error.WriteLine("You can Buy/Sell this amount Land");
        }
    }
}