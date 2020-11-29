using System;
using Xunit;

namespace aufgabe5.tests
{
    public class UrlTest
    {
        [Fact]
        public void SmokeTest()
        {       
        }

        [Fact]
        public void When_Ctor__Given_Url__Expect_Url()
        {
            var url = new URL("https://www.google.com/");
            Assert.Equal(url.Url, "https://www.google.com/");
        }

        [Fact]
        public void When_Ctor__Given_Url__Expect_Scheme()
        {
            var url = new URL("https://www.google.com/");
            Assert.Equal(url.Scheme, "https");
        }

        [Fact]
        public void When_Ctor__Given_Url__Expect_Host()
        {
            var url = new URL("https://www.google.com/");
            Assert.Equal(url.Host, "www.google.com");
        }

        [Fact]
        public void When_Ctor__Given_Url__Expect_Path()
        {
            var url = new URL("https://www.hs-esslingen.de/studium/bewerbung/bewerbung-fuer-einen-bachelor-studiengang/");
            Assert.Equal(url.Path, "studium/bewerbung/bewerbung-fuer-einen-bachelor-studiengang/");
        }

        [Fact]
        public void When_Ctor__Given_Url__Expect_Url_Schema_Host_Path()
        {
            var url = new URL("https://sports.tipico.de/de");
            Assert.Equal(url.Url, "https://sports.tipico.de/de");
            Assert.Equal(url.Scheme, "https");
            Assert.Equal(url.Host, "sports.tipico.de");
            Assert.Equal(url.Path, "de");
        }

        [Fact]
        public void When_Ctor__Given_Url__Expect_Url_Schema_Host_NoPath()
        {
            var url = new URL("https://www.kirchentag.de");
            Assert.Equal(url.Url, "https://www.kirchentag.de");
            Assert.Equal(url.Scheme, "https");
            Assert.Equal(url.Host, "www.kirchentag.de");
            Assert.Equal(url.Path, "");
        }
              
        [Fact]
        public void When_Ctor__Given_Url_File_three_Schlash__Expect_Url_Schema_Path()
        {
            var url = new URL("file:///tmp/mozilla_bradfisch0/Antrag_auf_Exmatrikulation.pdf");
            Assert.Equal(url.Url, "file:///tmp/mozilla_bradfisch0/Antrag_auf_Exmatrikulation.pdf");
            Assert.Equal(url.Scheme, "file");
            Assert.Equal(url.Path, "tmp/mozilla_bradfisch0/Antrag_auf_Exmatrikulation.pdf");
        }

        [Fact]
        public void When_Ctor__Given_Url_File_Schlash__Expect_Url_Schema_Path()
        {
            var url = new URL("file:/tmp/mozilla_bradfisch0/Taetigkeitsnachweis_deutsch_2009_10_16.pdf");
            Assert.Equal(url.Url, "file:/tmp/mozilla_bradfisch0/Taetigkeitsnachweis_deutsch_2009_10_16.pdf");
            Assert.Equal(url.Scheme, "file");
            Assert.Equal(url.Path, "tmp/mozilla_bradfisch0/Taetigkeitsnachweis_deutsch_2009_10_16.pdf");
        }

        [Fact]
        public void When_Ctor__Given_Url_File_Schlash_Schlash__Expect_Url_Schema_Path()
        {
            var url = new URL("file://localhost/it_mp_wahlpflichtfach.pdf");
            Assert.Equal(url.Url, "file://localhost/it_mp_wahlpflichtfach.pdf");
            Assert.Equal(url.Scheme, "file");
            Assert.Equal(url.Path, "it_mp_wahlpflichtfach.pdf");
        }

        [Theory]
        [InlineData(":///some/path/to/document.pdf")]
        [InlineData("/some/path/to/document.pdf")]
        [InlineData("123://localhost/document.pdf")]
         public void When_Ctor__Given_BadUrl__Expect_Exception(string input)
        {
            Assert.Throws<FormatException>(() => new URL(input));
        }
        
        [Fact]
        public void When_ToString__Given_Url__Expect_String()
        {
            var url = new URL("https://sports.tipico.de/de").ToString();
            Assert.Equal(url, "https://sports.tipico.de/de");
        }
    }
}