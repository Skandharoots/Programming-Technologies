using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data.API;
using System.Linq;

namespace DataTest
{
    [TestClass]
    public class UnitTest1
    {
        private DataLayerAPI dataLayer;


        [TestMethod]
        public void GetAllClientsTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(0, dataLayer.GetAllClients().Count());
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(0, dataLayer.GetAllEvents().Count());
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(0, dataLayer.GetAllRecords().Count());
        }

        [TestMethod]
        public void GetAllRecordStatusesTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(0, dataLayer.GetAllRecordStatuses().Count());
        }
    }
}
