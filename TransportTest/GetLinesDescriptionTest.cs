using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TransportLibrary.GetData;
using TransportLibrary.SendRequest;

namespace TransportTest
{
    [TestClass]
    public class GetLinesDescriptionTest
    {
        [TestMethod]
        public void ExpectStringOfListReturnsCorrectValues()
        {
            //Arrange
            ISendRequest fakeRequest = new FakeSendRequest();
            GetLinesNearDescription target = new GetLinesNearDescription(fakeRequest);
            List<string> list = new List<string> { "SEM:12", "SEM:16", "SEM:C" };
            //act
            string actualList = target.GetStringFromList(list);
            //Assert
            string expectedList = "SEM:12,SEM:16,SEM:C";
            Assert.AreEqual(actualList, expectedList);
        }
    }
}
