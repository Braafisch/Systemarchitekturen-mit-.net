using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace aufgabe8.tests
{
    public class UnitTest1
    {
        [Fact]
        public void SmokeTest()
        {
        }
        [Fact]
        public void When_Filter__Given_No_Parameters__Expect_Current_Month_Year_Filter()
        {
            var filter = new Filter();
            Assert.Equal(filter.month, DateTime.Now.Month);
            Assert.Equal(filter.year, DateTime.Now.Year);
        }
        [Fact]
        public void When_Filter__Given_One_Parameters__Expect_Current_Month_Year_Filter()
        {
            var filter = new Filter(3);
            Assert.Equal(filter.month, 3);
            Assert.Equal(filter.year, DateTime.Now.Year);
        }
        [Fact]
        public void When_Filter__Given_Two_Parameters__Expect_Current_Month_Year_Filter()
        {
            var filter = new Filter(3, 2015);
            Assert.Equal(filter.month, 3);
            Assert.Equal(filter.year, 2015);
        }
        [Fact]
        public void When_GetData__Given_Entries__Expect_Entries()
        {
            var dataStorage = new DataStorage("tests_1.csv");
            var entry = new Entry(new DateTime(2019, 03, 01), "Food", 4);
            dataStorage.AddBooking(entry);
            var data = dataStorage.GetData();
            File.Delete("tests_1.csv");
            Assert.Equal(data.Count, 1);
            Assert.Equal(data[0].date, entry.date);
            Assert.Equal(data[0].usecase, entry.usecase);
            Assert.Equal(data[0].money, entry.money);
        }
        [Fact]
        public void When_SearchEntries__Given_One_Fiting_Entry__Expect_One_Entry()
        {
            var onFiltered = new Mock<Action<List<Entry>>>();
            var onEmpty = new Mock<Action>();

            var dataStorage = new DataStorage("tests_2.csv");
            var filter = new Filter(3, 2019);
            dataStorage.AddBooking(new Entry(new DateTime(2019, 03, 01), "Food", 4));
            dataStorage.AddBooking(new Entry(new DateTime(2014, 03, 01), "Food", 4));
            filter.SearchEntries(entries: dataStorage.GetData(),
                                 onFiltered: onFiltered.Object,
                                 onEmpty: onEmpty.Object
                                 );
            File.Delete("tests_2.csv");
            onFiltered.Verify(act => act.Invoke(
                It.Is<List<Entry>>(
                    entries => entries.Count == 1
                    && entries[0].date.Year == 2019
                    && entries[0].date.Month == 3
                    && entries[0].date.Day == 1)), Times.Once());
            onEmpty.VerifyNoOtherCalls();
        }
        [Fact]
        public void When_SearchEntries__Given_No_Fiting_Entry__Expect_No_Entry()
        {
            var onFiltered = new Mock<Action<List<Entry>>>();
            var onEmpty = new Mock<Action>();

            var dataStorage = new DataStorage("tests_3.csv");
            var filter = new Filter();
            var entry1 = new Entry(new DateTime(2019, 03, 01), "Food", 4);
            var entry2 = new Entry(new DateTime(2014, 03, 01), "Food", 4);
            dataStorage.AddBooking(entry1);
            dataStorage.AddBooking(entry2);
            var entries = dataStorage.GetData();
            File.Delete("tests_3.csv");
            filter.SearchEntries(entries: entries,
                                 onFiltered: onFiltered.Object,
                                 onEmpty: onEmpty.Object
                                 );
            onFiltered.VerifyNoOtherCalls();
            onEmpty.Verify(act => act.Invoke(), Times.Once());
        }
    }
}
