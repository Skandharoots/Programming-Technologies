using Data;
using Data.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace TestData
{
    [TestClass]
    public class DataTest
    {
        private DataLayerAPI dataLayer;


        [TestMethod]
        public void GetAllClientsTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(2, dataLayer.GetAllClients().Count());
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(2, dataLayer.GetAllEvents().Count());
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(2, dataLayer.GetAllRecords().Count());
        }

        [TestMethod]
        public void GetAllRecordStatusesTest()
        {
            dataLayer = DataLayerAPI.CreateLayer();
            Assert.AreEqual(2, dataLayer.GetAllRecordStatuses().Count());
        }
    }
}
