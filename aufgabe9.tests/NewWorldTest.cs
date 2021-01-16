using System;
using Xunit;
using Moq;

namespace aufgabe9.tests
{
    public class NewWorldTest
    {
        [Fact]
        public void SmokeTest()
        {
        }
        [Fact]
        public void When_PossessionLogic_Buy__Given_Buy_One_Land__Expect_Updated_Possession()
        {
            var possession = new Possession(100);
            new PossessionLogic().Buy(1, possession);
            Assert.Equal(possession.land, 1);
            Assert.Equal(possession.money, 50);
        }
        [Fact]
        public void When_PossessionLogic_Buy__Given_Bad_Number_Land_Expect_Exception()
        {
            var possession = new Possession(100);
            Assert.Throws<InvalidOperationException>(() => new PossessionLogic().Buy(3, possession));
        }
        
        [Fact]
        public void When_Possession_Sell__Given_Sell_One_Land__Expect_Updated_Possession()
        {
            var possession = new Possession(200);
            var possessionLogic = new PossessionLogic();
            possessionLogic.Buy(2, possession);
            possessionLogic.Sell(1, possession);
            Assert.Equal(possession.land, 1);
            Assert.Equal(possession.money, 145);
        }
        [Fact]
        public void When_Possession_Sell__Given_Sell_Bad_Land__Expect_Exception()
        {
            var possession = new Possession(200);
            var possessionLogic = new PossessionLogic();
            possessionLogic.Buy(2, possession);
            Assert.Throws<InvalidOperationException>(() => possessionLogic.Sell(5, possession));
        }
    }
}
