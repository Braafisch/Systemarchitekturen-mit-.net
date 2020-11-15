using System;
using Xunit;

namespace aufgabe3.tests
{
    public class NStepsTest
    {
        [Fact]
        public void SmokeTest()
        {
        }

        [Fact]
        public void When_Ctor__Expect_SomeObject()
        {
            // execute
            var result = new NSteps();

            // verify
            Assert.NotNull(result);
        }

        [Fact]
        public void When_GetNumber__Given_XZeroYZero__Expect_Zero()
        {
            // setup
            var nstep = new NSteps();

            // execute
            var result = nstep.GetNumber(0, 0);

            // verify
            Assert.Equal("0", result);
        }

        [Fact]
        public void When_GetNumber__Given_XTwoYTwo__Expect_Four()
        {
            // setup
            var nstep = new NSteps();

            // execute
            var result = nstep.GetNumber(2, 2);

            // verify
            Assert.Equal("4", result);
        }

        [Fact]
        public void When_GetNumber__Given_XOneYOne__Expect_One()
        {
            // setup
            var nstep = new NSteps();

            // execute
            var result = nstep.GetNumber(1, 1);

            // verify
            Assert.Equal("1", result);
        }

        [Fact]
        public void When_GetNumber__Given_XTwoYZero__Expect_Two()
        {
            // setup
            var nstep = new NSteps();

            // execute
            var result = nstep.GetNumber(2, 0);

            // verify
            Assert.Equal("2", result);
        }

        [Fact]
        public void When_GetNumber__Given_XZeroYOne__Expect_NoNumber()
        {
            // setup
            var nstep = new NSteps();

            // execute
            var result = nstep.GetNumber(0, 1);

            // verify
            Assert.Equal("No Number", result);
        }

        [Theory]
        [InlineData(1, 1, "1")]
        [InlineData(3, 1, "3")]
        [InlineData(3, 3, "5")]
        [InlineData(4, 2, "6")]
        [InlineData(5, 3, "7")]
        [InlineData(4, 4, "8")]
        [InlineData(5, 5, "9")]
        [InlineData(6, 4, "10")]
        [InlineData(7, 5, "11")]
        [InlineData(6, 6,"12")]
        public void When_GetNumber__Given_KnownGoodXY__Expect_Number(int x, int y, string expected)
        {
            // setup
            var nstep = new NSteps();

            // execute
            var result = nstep.GetNumber(x, y);

            // verify
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(0, 4)]
        [InlineData(0, 5)]
        [InlineData(0, 6)]
        [InlineData(1, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(5, 0)]
        [InlineData(6, 0)]
        [InlineData(7, 0)]
        public void When_GetNumber__Given_KnownBadXY__Expect_NoNumber(int x, int y)
        {
            // setup
            var nstep = new NSteps();

            // execute
            var result = nstep.GetNumber(x, y);

            // verify
            Assert.Equal("No Number", result);
        }
    }
}
