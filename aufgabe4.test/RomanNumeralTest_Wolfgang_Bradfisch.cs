using System;
using Xunit;

namespace aufgabe4.test
{
    public class UnitTest1
    {
        [Fact]
        public void SmokeTest()
        {
        }

        [Fact]
        public void When_Ctor__Expect_SomeObject()
        {
            var num = new RomanNumeral();
        }

        [Fact]
        public void When_ToInt32__Given_I__Expect_One()
        {
            // setup
            var num = new RomanNumeral('I');

            // execute
            var result = num.ToInt32();

            // verify
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData('V', 5)]
        [InlineData('X', 10)]
        [InlineData('L', 50)]
        [InlineData('C', 100)]
        [InlineData('D', 500)]
        [InlineData('M', 1000)]
        public void When_ToInt32__Given_KnownGoodRomanNumeral__Expect_Number(char roman, int expected)
        {
            var num = new RomanNumeral(roman);

            var result = num.ToInt32();

            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('E')]
        [InlineData('F')]
        [InlineData('G')]
        [InlineData('H')]
        public void When_ToInt32__Given_KnownBadRomanNumeral__Expect_Exception(char roman)
        {
            var num = new RomanNumeral(roman);

            Assert.Throws<ArgumentException>(() => num.ToInt32());
        }

        [Fact]
        public void When_ToInt32__Given_VI__Expect_Six()
        {
            var num = new RomanNumeral("VI");

            var result = num.ToInt32();

            Assert.Equal(6, result);
        }

        [Fact]
        public void When_ToInt32__Given_IV__Expect_Four()
        {
            var num = new RomanNumeral("VI");

            var result = num.ToInt32();

            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData("VII", 7)]
        [InlineData("XV", 15)]
        [InlineData("XVIII", 18)]
        [InlineData("MMXIII", 2013)]
        [InlineData("MCMXC", 1990)]
        [InlineData("MMVIII", 2008)]
        [InlineData("XCIX", 99)]
        [InlineData("MCMXCIX", 1999)]
        public void When_ToInt32__Given_KnownLongGoodRomanNumeral__Expect_Number(string roman, int expected)
        {
            var num = new RomanNumeral(roman);

            var result = num.ToInt32();

            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("IIII")]
        [InlineData("IIV")]
        [InlineData("VX")]
        [InlineData("IL")]
        [InlineData("IMIIX")]
        [InlineData("VV")]
        [InlineData("LL")]
        [InlineData("IM")]
        [InlineData("CMM")]
        public void When_ToInt32__Given_KnownLongBadRomanNumeral__Expect_Exception(string roman)
        {
            var num = new RomanNumeral(roman);

            Assert.Throws<ArgumentException>(() => num.ToInt32());
        }
    }
}
