using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebLogic;

namespace Tests
{
    public class CurrencyClientTest
    {
        [Fact]
        public void GetXMLTest()
        {
            //Arrange
            CurrencyClient currencyClient = new CurrencyClient();
            //Act
            string result = currencyClient.GetXML("31.03.2021");
            //Assert
            Assert.Contains("USD", result);
        }
        [Fact]
        public void ParseValuteTest()
        {
            //Arrange
            CurrencyClient currencyClient = new CurrencyClient();
            string expectedName = "Foreign Currency Market";
            string expectedDate = "31.03.2021";
            var expectedValutesType = typeof(List<Valute>);
            //Act
            var result = currencyClient.ParseValute(currencyClient.GetXML("31.03.2021"));
            //Assert
            Assert.Equal(expectedDate, result.Date);
            Assert.Equal(expectedName, result.Name);
            Assert.IsType(expectedValutesType, result.Valutes);
        }
        [Fact]
        public void GetXMLNullTest()
        {
            //Arrange
            CurrencyClient currencyClient = new CurrencyClient();
            //Act
            Action act = () => currencyClient.GetXML(null);
            //Assert
            Exception exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'date')", exception.Message);
        }
        [Fact]
        public void ParseValuteNullTest()
        {
            //Arrange
            CurrencyClient currencyClient = new CurrencyClient();
            //Act
            Action act = () => currencyClient.ParseValute(null);
            //Assert
            Exception exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'xml')", exception.Message);
        }
    }
}
