using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TransportConsole.Request;
using TransportConsole.SendRequest;

namespace TransportTest
{
    [TestClass]
    public class LinesNearRequestTest
    {
        [TestMethod]
        public void ConstructorWithNoValuesReturnsCorrectUrl()
        {
            //Arrange
            ISendRequest fakeSendRequest = new FakeSendRequest();
            string expectedUrl = "https://data.mobilites-m.fr/api/linesNear/json?x=5.728043&y=45.18432&dist=500&details=True";
            //Act
            LinesNearRequest target = new LinesNearRequest(fakeSendRequest);
            string actualUrl = target.Url;
            //Assert
            Assert.AreEqual(actualUrl, expectedUrl);
        }

        [TestMethod]
        public void ConstructorWithStringValuesReturnsCorrectUrl()
        {
            //Arrange
            ISendRequest fakeSendRequest = new FakeSendRequest();
            string x = "5.728043";
            string y = "45.18432";
            string z = "500";
            string expectedUrl = "https://data.mobilites-m.fr/api/linesNear/json?x=5.728043&y=45.18432&dist=500&details=True";
            //Act
            LinesNearRequest target = new LinesNearRequest(fakeSendRequest, x, y, z);
            string actualUrl = target.Url;
            //Assert
            Assert.AreEqual(actualUrl, expectedUrl);
        }

        [TestMethod]
        public void ConstructorWithDoubleValuesReturnsCorrectUrl()
        {
            //Arrange
            ISendRequest fakeSendRequest = new FakeSendRequest();
            double x = 5.728056;
            double y = 45.18474;
            int z = 200;
            string expectedUrl = "https://data.mobilites-m.fr/api/linesNear/json?x=5.728056&y=45.18474&dist=200&details=True";
            //Act
            LinesNearRequest target = new LinesNearRequest(fakeSendRequest, x, y, z);
            string actualUrl = target.Url;
            //Assert
            Assert.AreEqual(actualUrl, expectedUrl);
        }
    }
}
