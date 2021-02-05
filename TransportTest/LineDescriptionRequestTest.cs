using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TransportLibrary.Request;
using TransportLibrary.SendRequest;

namespace TransportTest
{
    [TestClass]
    public class LineDescriptionRequestTest
    {
        [TestMethod]
        public void ConstructorWithNoValuesReturnsCorrectUrl()
        {
            //Arrange
            ISendRequest fakeSendRequest = new FakeSendRequest();
            string line = "SEM:12";
            string expectedUrl = "https://data.mobilites-m.fr/api/routers/default/index/routes?codes=SEM:12";
            //Act
            LineDescriptionRequest target = new LineDescriptionRequest(fakeSendRequest, line);
            string actualUrl = target.Url;
            //Assert
            Assert.AreEqual(actualUrl, expectedUrl);
        }
    }
}
