using System;

namespace aufgabe9
{
    public class UserInteraction
    {
        public void MainMenu(Possession possession,
                             Action onMangeLand,
                             Action onEnd)
        {
            Console.WriteLine("1. Land verwalten\n2. Runde beenden");
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
            Console.WriteLine("1. Land kaufen\n2. Land verkaufen\n3. Zurück");
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
            Console.WriteLine("Wie viel Land soll verkauft werden?");
            return int.Parse(Console.ReadLine());
        }
        public int Buy()
        {
            Console.WriteLine("Wie viel Land soll gekauft werden?");
            return int.Parse(Console.ReadLine());
        }
        public void PrintErr()
        {
            Console.Error.WriteLine("You can Buy/Sell this amount Land");
        }
    }
}