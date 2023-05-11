using Service.API;
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
            IRecordStatusCRUD recordStatusService = IRecordStatusCRUD.CreateRecordStatus(new DataLayerMock());
            IRecordCRUD recordService = IRecordCRUD.CreateRecord(new DataLayerMock());
            recordService.AddRecord("Led Zeppelin", "Houses of the holy");
            recordStatusService.AddRecordStatus(1, false);
            Assert.IsNotNull(recordStatusService.GetRecordStatus(1));
            recordStatusService.DeleteRecordStatus(1);

        }

        [TestMethod]
        public void TestUpdateRecordStatus()
        {
            IRecordStatusCRUD recordStatusService = IRecordStatusCRUD.CreateRecordStatus(new DataLayerMock());
            recordStatusService.AddRecordStatus(1, false);
            recordStatusService.UpdateRecordStatusRecordId(1, 3);
            Assert.AreEqual(recordStatusService.GetRecordStatus(1).RecordId, 3);
            recordStatusService.UpdateRecordStatusSold(1, true);
            Assert.AreEqual(recordStatusService.GetRecordStatus(1).Sold, true);
            recordStatusService.DeleteRecordStatus(1);
        }

        [TestMethod]
        public void TestGetAllRecordStatuss()
        {
            IRecordStatusCRUD recordService = IRecordStatusCRUD.CreateRecordStatus(new DataLayerMock());
            recordService.AddRecordStatus(1, false);
            Assert.AreEqual(1, recordService.GetAllRecordStatuses().Count());
        }
    }
}

