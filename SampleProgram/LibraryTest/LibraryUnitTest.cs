using NUnit.Framework;
using RecordStore;

namespace TestLibrary
{
    public class Tests
    {
        //LogicTests

        [Test]
        public void FillRandom() 
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            random.Fill(cont);
            int clients = cont.clients.Count;
            Assert.IsNotNull(clients);
            int records = cont.records.Count;
            Assert.IsNotNull(records);
            int events = cont.events.Count;
            Assert.IsNotNull(events);
            int recordStatuses = cont.recordStatuses.Count;
            Assert.IsNotNull(recordStatuses);
        }

        [Test]
        public void FillRandomClients()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 30;
            random.FillClients(cont);
            int actual = cont.clients.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillRandomRecords()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 10;
            random.FillRecords(cont);
            int actual = cont.records.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillRandomEvents()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 30;
            random.FillClients(cont);
            random.FillRecords(cont);
            random.FillRecordStatuses(cont);
            random.FillEvents(cont);
            int actual = cont.events.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillRandomRecordStatuses()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 10;
            random.FillRecords(cont);
            random.FillRecordStatuses(cont);
            int actual = cont.recordStatuses.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantClients()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.FillClients(cont);
            int expAmount = 20;
            int actual = cont.clients.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantRecords()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.FillRecords(cont);
            int expAmount = 20;
            int actual = cont.records.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantRecordStatuses()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.Fill(cont);
            int expAmount = 20;
            int actual = cont.recordStatuses.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantEvents()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.Fill(cont);
            int expAmount = 20;
            int actual = cont.events.Count;
            Assert.AreEqual(actual, expAmount);
        }


        [Test]
        public void Test1()
        {
            Record record = new Record("Nevermind", "Kurt Cobain");
            string actual = record.Title;
            Console.WriteLine(record.ToString());
            Assert.AreEqual("Nevermind", actual);
            RecordStatus rstatus = new RecordStatus(record, DateTime.Today);
            DateTime actualTime = DateTime.Today;
            Assert.AreEqual(actualTime, rstatus.DateOfPurchase);
            DateTime rentalDate = new DateTime(2022, 05, 23);
            Event eventOne = new Event(record, new Client("Marek", "Kopania"), rentalDate, DateTime.Now);
            Console.WriteLine(eventOne.ToString());
        }
    }
}