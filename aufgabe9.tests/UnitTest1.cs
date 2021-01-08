using System;
using Xunit;

namespace aufgabe9.tests
{
    public class UnitTest1
    {
        [Fact]
        public void SmokeTest()
        {
        }
        [Fact]
        public void When_PossessionBuy__Given_Count__Expect_Land_Money()
        {
            var possession = new Possesion(100);
            possession.Buy(2);
            Assert.Equal("Geld: 0 | Land: 2", possession.ToString());
        }
    }
}
