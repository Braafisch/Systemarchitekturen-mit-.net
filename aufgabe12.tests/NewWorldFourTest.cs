using System;
using Xunit;

namespace aufgabe12.tests
{
    public class UnitTest1
    {
        [Fact]
        public void SmokeTest()
        {
        }
        [Fact]
        public void When_PossessionLogic_BuyGood__Given_Count__Updated_Possession()
        {
            var warehouse = new Warehouse();
            warehouse.AddGood("weed", 25, 25);
            var possession = new Possession(100, 5, 20, warehouse);
            new PossessionLogic().BuyGoods(2, "weed", possession);
            Assert.Equal(possession.money, 50);
            Assert.Equal(possession.warehouse.goods["weed"].amount, 27);
        }
        [Fact]
        public void When_PossessionLogic_SellGood__Given_Count__Expect_Updated_Possession()
        {
            var warehouse = new Warehouse();
            warehouse.AddGood("weed", 25, 25);
            var possession = new Possession(100, 5, 20, warehouse);
            new PossessionLogic().SellGoods(5, "weed", possession);
            Assert.Equal(possession.money, 210);
            Assert.Equal(possession.warehouse.goods["weed"].amount, 20);
        }
        [Fact]
        public void When_PossessionLogic_BuyGoods__Given_Bad_Number_Weed_Expect_Exception()
        {
            var warehouse = new Warehouse();
            warehouse.AddGood("weed", 25, 25);
            var possession = new Possession(100, 5, 20, warehouse);
            Assert.Throws<InvalidOperationException>(() => new PossessionLogic().BuyGoods(5, "weed", possession));
        }
        [Fact]
        public void When_PossessionLogic_SellGoods__Given_Bad_Number_Weed_Expect_Exception()
        {
            var warehouse = new Warehouse();
            warehouse.AddGood("weed", 25, 25);
            var possession = new Possession(100, 5, 20, warehouse);
            Assert.Throws<InvalidOperationException>(() => new PossessionLogic().SellGoods(27, "weed", possession));
        }
    }
}
