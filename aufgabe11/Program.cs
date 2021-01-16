using System;

namespace aufgabe11
{
    class Program
    {
        internal UserInteraction UserInteraction;
        internal PossessionLogic PossessionLogic;
        internal Possession Possession;
        internal Program()
        {
            UserInteraction = new UserInteraction();
            PossessionLogic = new PossessionLogic();
            Possession = ConfigPlayer(money: 100, land: 5, weed: 25, oil: 10, metal: 5, christall: 0);
        }
        static void Main(string[] args)
        {
            new Program().Run();
        }
        private void Run()
        {
            var End = false;
            while (!End)
            {
                Console.WriteLine(Possession.ToString());
                Console.WriteLine("---");
                UserInteraction.MainMenu(onMangeLand: MangeLand,
                                         onVisitMarket: VisitMarket,
                                         onEnd: () => { End = true; });
            }
        }
        private void MangeLand()
        {
            var Back = false;
            while (!Back)
            {
                Console.WriteLine(Possession.ToString());
                Console.WriteLine("---");
                UserInteraction.ManageLandMenu(onBuy: () =>               
                                               {
                                                   PossessionLogic.BuyLand(count: UserInteraction.AmountToBuy(),
                                                                           possession: Possession);
                                               },
                                               onSell: () =>
                                               {
                                                   PossessionLogic.SellLand(count: UserInteraction.AmountToSell(),
                                                                            possession: Possession);
                                               },
                                               onBack: () => { Back = true; });
            }
        }
        private void VisitMarket()
        {
            var Back = false;
            while (!Back)
            {
                Console.WriteLine(Possession.ToString());
                Console.WriteLine("---");
                UserInteraction.ManageMarketMenu(onBuy: () =>               
                                               {
                                                   PossessionLogic.BuyWeed(count: UserInteraction.AmountToBuy(),
                                                                           possession: Possession);
                                               },
                                               onSell: () =>
                                               {
                                                   PossessionLogic.SellWeed(count: UserInteraction.AmountToSell(),
                                                                            possession: Possession);
                                               },
                                               onBack: () => { Back = true; });
            }
        }
        private Possession ConfigPlayer(int money, int land, int weed, int oil, int metal, int christall)
        {
            var warehouse = new Warehouse(weed: weed, oil: oil, metal: metal, christall: christall);
            var possession = new Possession(money: money, land: land, warehouse: warehouse);
            return possession;
        }
    }
}
