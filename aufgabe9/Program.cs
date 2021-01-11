using System;

namespace aufgabe9
{
    class Program
    {
        internal UserInteraction UserInteraction;
        internal Possession Possession;  
        internal PossessionLogic PossessionLogic;
        internal Program(int money)
        {
            UserInteraction = new UserInteraction();
            Possession = new Possession(money);
            PossessionLogic = new PossessionLogic();
        }
        static void Main(string[] args)
        {
            new Program(100).Run();
        }
        private void Run()
        {
            var End = false;
            while (!End)
            {
                Console.WriteLine(Possession.ToString());
                Console.WriteLine("---");
                UserInteraction.MainMenu(onMangeLand: MangeLand,
                                         onEnd: () => {End = true;});
            }
        }
        private void MangeLand()
        {
            var Back = false;
            while(!Back)
            {
                Console.WriteLine(Possession.ToString());
                Console.WriteLine("---");
                UserInteraction.ManageLandMenu(onBuy: Buy,
                                               onSell: Sell,
                                               onBack: () => {Back = true;});
            }
        }
        private void Buy()
        {
            var count = UserInteraction.Buy();
            PossessionLogic.Buy(count: count,
                                possession: Possession);
        }
        private void Sell()
        {
            var count = UserInteraction.Sell();
            PossessionLogic.Sell(count: count,
                                possession: Possession);
        }
    }
}
