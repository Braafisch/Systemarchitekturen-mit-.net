using System;

namespace aufgabe12
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
            Possession = ConfigPlayer(money: 100, land: 5, settlers: 20, weed: 25, oil: 10, metal: 5, christall: 0);
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
                UserInteraction.ManageMarketMenu(onBuy: BuyGoods,
                                                 onSell: SellGoods,
                                                 onBack: () => { Back = true; });
            }
        }
        private void BuyGoods()
        {
            UserInteraction.ManageBuyGoodsMenu(warehouse: Possession.warehouse,
                                               onGood: (goodName) =>
                                               {
                                                   PossessionLogic.BuyGoods(goodName: goodName,
                                                                            count: UserInteraction.AmountToBuy(),
                                                                            possession: Possession);
                                               },
                                               onAbort: () => { });
        }
        private void SellGoods()
        {
            UserInteraction.ManageSellGoodsMenu(warehouse: Possession.warehouse,
                                                onGood: (goodName) =>
                                                {
                                                    PossessionLogic.SellGoods(goodName: goodName,
                                                    count: UserInteraction.AmountToSell(),
                                                    possession: Possession);
                                                },
                                                onAbort: () => { });
        }
        private Possession ConfigPlayer(int money, int land, int settlers, int weed, int oil, int metal, int christall)
        {
            var warehouse = new Warehouse();
            warehouse.AddGood(goodName: "weed", amount: weed, value: 25);
            warehouse.AddGood(goodName: "oil", amount: oil, value: 50);
            warehouse.AddGood(goodName: "metal", amount: metal, 60);
            warehouse.AddGood(goodName: "christall", amount: christall, 75);
            var possession = new Possession(money: money, land: land, settlers: settlers, warehouse: warehouse);
            return possession;
        }
    }
}
