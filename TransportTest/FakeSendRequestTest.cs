using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TransportConsole;

namespace TransportTest
{
    [TestClass]
    public class FakeSendRequestTest
    {
        [TestMethod]
        public void DoRequestWithEmptyUrlReturnsCorrectResponse()
        {
            //Arrange
            FakeSendRequest fakeSendRequest = new FakeSendRequest();
            string expectedResponse = "no response";
            //Act
            string actualResponse = fakeSendRequest.DoRequest();
            //Assert
            Assert.AreEqual(actualResponse, expectedResponse);
        }

        [TestMethod]
        public void DoRequestWithUrlContainsNearLinesReturnsCorrectResponse()
        {
            //Arrange
            string url = "http://data.mobilites-m.fr/api/linesNear/json?x=5.709360123&y=45.176494599999984&dist=400&details=true";
            FakeSendRequest fakeSendRequest = new FakeSendRequest(url);
            string expectedResponse = "[{ id: 'SEM:0844', name: 'Grenoble, Champs-Elysées', lon: 5.71025,lat: 45.17794,zone: 'SEM_GENCHAMPSEL', lines:['SEM:12']},{ id: 'SEM:0846',name: 'Grenoble, Salengro',lon: 5.70893,lat: 45.17557,zone: 'SEM_GENSALENGRO',lines:['SEM:12']}]";
            //Act
            string actualResponse = fakeSendRequest.DoRequest();
            //Assert
            Assert.AreEqual(actualResponse, expectedResponse);
        }

        [TestMethod]
        public void DoRequestWithUrlContainsLinesReturnsCorrectResponse()
        {
            //Arrange
            string url = "http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=SEM_C1 ";
            FakeSendRequest fakeSendRequest = new FakeSendRequest(url);
            string expectedResponse = "{ type: 'FeatureCollection', features:[ ] }";
            //Act
            string actualResponse = fakeSendRequest.DoRequest();
            //Assert
            Assert.AreEqual(actualResponse, expectedResponse);
        }
    }
}
