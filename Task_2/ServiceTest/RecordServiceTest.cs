﻿using Service.API;
using Service.Implementation;

namespace ServiceTest
{
    [TestClass]
    public class RecordServiceTest
    {
        [TestMethod]
        public void TestAddDeleteRecord()
        {
            IRecordCRUD recordService = IRecordCRUD.CreateRecord(new DataLayerMock());
            recordService.AddRecord("Nirvana", "Nevermind");
            Assert.IsNotNull(recordService.GetRecord(1));
            recordService.DeleteRecord(1);

        }

        [TestMethod]
        public void TestUpdateRecord()
        {
            IRecordCRUD recordService = IRecordCRUD.CreateRecord(new DataLayerMock());
            recordService.AddRecord("Nirvana", "Nevermind");
            recordService.UpdateAuthor(1, "Konrad");
            Assert.AreEqual(recordService.GetRecord(1).Author, "Konrad");
            recordService.UpdateTitle(1, "Not me");
            Assert.AreEqual(recordService.GetRecord(1).Title, "Not me");
            recordService.DeleteRecord(1);
        }

        [TestMethod]
        public void TestGetAllRecords()
        {
            IRecordCRUD recordService = IRecordCRUD.CreateRecord(new DataLayerMock());
            recordService.AddRecord("Marek", "Kopania");
            Assert.AreEqual(1, recordService.GetAllRecords().Count());
        }
    }
}
