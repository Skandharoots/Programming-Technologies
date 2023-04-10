using NuGet.Frameworks;
using RecordStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibraryLogic
{
    internal class LogicLayerTest
    {

        [Test]
        public void RepositoryAddClient()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            Client c1 = new Client("Mateusz", "Kubiak");
            repo.AddClient(c1);
            int expected = 1;
            int actual = repo.DataContext.clients.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteClient() 
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            int amount = repo.DataContext.clients.Count;
            Client c = repo.GetClient(0);
            repo.DeleteClient(c);
            int expected = amount - 1;
            int actual = repo.DataContext.clients.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetClient() 
        {
            DataRepository repo = new DataRepository(new FillConstant());
            Client c = new Client("A", "A");
            repo.AddClient(c);
            Client actual = repo.GetClient(0);
            Assert.AreSame(c, actual);
        }

        [Test]
        public void RepositoryGetAllClients()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            List<Client> allClients = (List<Client>)repo.GetAllClients();
            bool allActualClients = repo.DataContext.clients.SequenceEqual(allClients);
            Assert.AreEqual(true, allActualClients);
        }

        [Test]
        public void RepositoryUpdateClient()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            string expectedName = "John";
            string expectedSurname = "Wick";
            repo.UpdateClient(3, "John", "Wick");
            Assert.AreEqual(expectedName, repo.GetClient(3).Name);
            Assert.AreEqual(expectedSurname, repo.GetClient(3).Surname);
        }

        [Test]
        public void RepositoryAddRecord()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            Record r = new Record("Nevermind", "Nirvana");
            repo.AddRecord(r);
            int expected = 1;
            int actual = repo.DataContext.records.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteRecord()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            int size = 20;
            repo.DeleteRecord(3);
            int expected = size - 1;
            int actual = repo.DataContext.records.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetRecord()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            Record r = new Record("A", "A");
            repo.AddRecord(r);
            Record actual = repo.GetRecord(0);
            Assert.AreEqual(r, actual);
        }

        [Test]
        public void RepositoryGetAllRecords()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            List<Record> allRecords = (List<Record>)repo.GetAllRecords();
            List<Record> allActualRecords = (List<Record>)repo.DataContext.records.Values.ToList();
            bool actual = allActualRecords.SequenceEqual(allRecords);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecord()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            string expectedAuthor = "Nirvana";
            string expectedTitle = "Nevermind";
            repo.UpdateRecord(5, "Nirvana", "Nevermind");
            Assert.AreEqual(expectedTitle, repo.GetRecord(5).Title);
            Assert.AreEqual(expectedAuthor, repo.GetRecord(5).Author);
        }

        [Test]
        public void RepositoryAddRecordStatus()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            RecordStatus expected = new RecordStatus(repo.DataContext.records.ElementAt(0).Value, DateTime.Today);
            repo.AddRecordStatus(expected);
            RecordStatus actual = repo.GetRecordStatus(20);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteRecordStatus()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            RecordStatus status = repo.GetRecordStatus(0);
            repo.DeleteRecordStatus(status);
            Assert.AreEqual(19, repo.DataContext.recordStatuses.Count);
        }

        [Test]
        public void RepositoryGetRecordStatus()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            RecordStatus expected = new RecordStatus(repo.DataContext.records.ElementAt(0).Value, DateTime.Today);
            repo.AddRecordStatus(expected);
            RecordStatus actual = repo.GetRecordStatus(20);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetAllRecordStatuses() 
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            List<RecordStatus> allStatuses = (List<RecordStatus>)repo.GetAllRecordStatus();
            bool actual = repo.DataContext.recordStatuses.SequenceEqual(allStatuses);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecordStatuses()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            Record expectedRecord = new Record("A", "A");
            DateTime expectedPurchaseDate = DateTime.Today;
            repo.UpdateStatus(0, expectedRecord, expectedPurchaseDate);
            Assert.AreEqual(expectedRecord, repo.DataContext.records.ElementAt(0).Value);
            Assert.AreEqual(expectedPurchaseDate, repo.GetRecordStatus(0).DateOfPurchase);
        }

        [Test]
        public void RepositoryAddEvent()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            Event e = new Event(repo.GetRecord(0), repo.GetClient(0), DateTime.Today);
            repo.AddEvent(e);
            int expected = 20 + 1;
            int actual = repo.DataContext.events.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteEvent() 
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            Event e = repo.GetEvent(0);
            repo.EventDelete(e);
            int actual = repo.DataContext.events.Count;
            Assert.AreEqual(19, actual);
        }

        [Test]
        public void RepositoryGetEvent()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            repo.Generate();
            Event expected = new Event(repo.DataContext.records.ElementAt(0).Value, repo.DataContext.clients[0], DateTime.Today);
            repo.AddEvent(expected);
            Event actual = repo.GetEvent(20);
            Assert.AreEqual(expected, actual);
        }
    }
}
