using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    [TestClass]
    public class RecordStatusServiceTest
    {

        [TestMethod]
        public void TestAddDeleteRecordStatus()
        {
            IRecordStatusCRUD recordStatusService = new RecordStatusCRUD(new DataLayerMock());
            IRecordCRUD recordService = new RecordCRUD(new DataLayerMock());
            recordService.AddRecord(1, "Led Zeppelin", "Houses of the holy");
            recordStatusService.AddRecordStatus(1, 1, false);
            Assert.IsNotNull(recordStatusService.GetRecordStatus(1));
            recordStatusService.DeleteRecordStatus(1);

        }

        [TestMethod]
        public void TestUpdateRecordStatus()
        {
            IRecordStatusCRUD recordStatusService = new RecordStatusCRUD(new DataLayerMock());
            recordStatusService.AddRecordStatus(1, 1, false);
            recordStatusService.UpdateRecordStatusRecordId(1, 3);
            Assert.AreEqual(recordStatusService.GetRecordStatus(1).RecordId, 3);
            recordStatusService.UpdateRecordStatusSold(1, true);
            Assert.AreEqual(recordStatusService.GetRecordStatus(1).Sold, true);
            recordStatusService.DeleteRecordStatus(1);
        }

        [TestMethod]
        public void TestGetAllRecordStatuss()
        {
            IRecordStatusCRUD recordService = new RecordStatusCRUD(new DataLayerMock());
            recordService.AddRecordStatus(1, 1, false);
            Assert.AreEqual(1, recordService.GetAllRecordStatuses().Count());
        }
    }
}

