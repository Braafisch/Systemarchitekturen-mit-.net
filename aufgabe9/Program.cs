using System;

namespace aufgabe9
{
    class Program
    {
        internal UserInteraction UserInteraction;
        internal Possession Possession;  
        internal Program(int money)
        {
            UserInteraction = new UserInteraction();
            Possession = new Possession(money);
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
                UserInteraction.MainMenu(possession: Possession,
                                         onMangeLand: secondLoob,
                                         onEnd: () => {End = true;});
            }
        }
        private void secondLoob()
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
            Possession.approvePurchase(count: count,
                                       onApprove: Possession.Buy,
                                       onNotApprove: UserInteraction.PrintErr);
                Possession.Buy(count);
        }
        private void Sell()
        {
            var count = UserInteraction.Sell();
            Possession.approveSell(count: count,
                                   onApprove: Possession.Sell,
                                   onNotApprove: UserInteraction.PrintErr);
        }
    }
}
