using System;
using Xunit;

namespace aufgabe10.tests
{
    public class UnitTest1
    {
        [Fact]
        public void SmokeTest()
        {
        }
        [Fact]
        public void When_PossessionLogic_BuyLand__Given_Buy_One_Land__Expect_Updated_Possession()
        {
            var possession = new Possession(100, 0, new Warehouse(0));
            new PossessionLogic().BuyLand(1, possession);
            Assert.Equal(possession.land, 1);
            Assert.Equal(possession.money, 50);
        }
        [Fact]
        public void When_PossessionLogic_BuyLand__Given_Bad_Number_Land_Expect_Exception()
        {
            var possession = new Possession(100, 0, new Warehouse(0));
            Assert.Throws<InvalidOperationException>(() => new PossessionLogic().BuyLand(3, possession));
        }
        
        [Fact]
        public void When_Possession_SellLand__Given_Sell_One_Land__Expect_Updated_Possession()
        {
            var possession = new Possession(200, 0, new Warehouse(0));
            var possessionLogic = new PossessionLogic();
            possessionLogic.BuyLand(2, possession);
            possessionLogic.SellLand(1, possession);
            Assert.Equal(possession.land, 1);
            Assert.Equal(possession.money, 145);
        }
        [Fact]
        public void When_PossessionLogic_SellLand__Given_Sell_Bad_Land__Expect_Exception()
        {
            var possession = new Possession(200, 0, new Warehouse(0));
            var possessionLogic = new PossessionLogic();
            possessionLogic.BuyLand(2, possession);
            Assert.Throws<InvalidOperationException>(() => possessionLogic.SellLand(5, possession));
        }
        [Fact]
        public void When_PossessionLogic_SellLand__Given_Sell_Land_Without_Buying__Expect_Exception()
        {
            var possession = new Possession(200, 5, new Warehouse(0));
            var possessionLogic = new PossessionLogic();
            Assert.Throws<InvalidOperationException>(() => possessionLogic.SellLand(2, possession));
        }
        [Fact]
        public void When_PossessionLogic_SellWeed__Given_Count__Expect_Updated_Possession()
        {
            var warehouse = new Warehouse(25);
            var possession = new Possession(100, 5, warehouse);
            new PossessionLogic().SellWeed(5, possession);
            Assert.Equal(possession.warehouse.weed, 20);
            Assert.Equal(possession.money, 210);
        }
        [Fact]
        public void When_PossessionLogic_SellWeed__Given_Bad_Number_Weed_Expect_Exception()
        {
            var warehouse = new Warehouse(5);
            var possession = new Possession(100, 5 , warehouse);
            Assert.Throws<InvalidOperationException>(() => new PossessionLogic().SellWeed(8, possession));
        }
        [Fact]
        public void When_PossessionLogic_BuyWeed__Given_Count__Expect_Updated_Possession()
        {
            var warehouse = new Warehouse(25);
            var possession = new Possession(100, 5, warehouse);
            new PossessionLogic().BuyWeed(2, possession);
            Assert.Equal(possession.money, 50);
            Assert.Equal(possession.warehouse.weed, 27);
        }
        [Fact]
        public void When_PossessionLogic_BuyWeed__Given_Bad_Number_Weed_Expect_Exception()
        {
            var warehouse = new Warehouse(25);
            var possession = new Possession(100, 5 , warehouse);
            Assert.Throws<InvalidOperationException>(() => new PossessionLogic().BuyWeed(5, possession));
        }
    }
}
