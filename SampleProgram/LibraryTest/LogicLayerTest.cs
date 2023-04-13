using NUnit.Framework;
using RecordStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    internal class LogicLayerTest
    {
        private DataRepository repo;
        private DataRepository repoE;
        private Client c;
        private Record r;
        private RecordStatus rs;
        private Event e;
        [SetUp]
        public void SetUp()
        {
            repo = new DataRepository(new FillConstant());
            repo.Generate();
            repoE = new DataRepository(new FillConstant());
            c = new Client("Mateusz", "Kubiak");
            r = new Record("Nevermind", "Nirvana");
            rs = new RecordStatus(repo.DataContext.records.ElementAt(0).Value, DateTime.Today);
        }

        [Test]
        public void RepositoryAddClient()
        {
           
            repoE.AddClient(c);
            int expected = 1;
            int actual = repoE.DataContext.clients.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteClient()
        {
            int amount = repo.DataContext.clients.Count;
            repo.DeleteClient(repo.GetClient(0));
            int expected = amount - 1;
            int actual = repo.DataContext.clients.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetClient()
        {
            repoE.AddClient(c);
            Assert.AreSame(c, repoE.GetClient(0));
        }

        [Test]
        public void RepositoryGetAllClients()
        {
            List<Client> allClients = (List<Client>)repo.GetAllClients();
            bool allActualClients = repo.DataContext.clients.SequenceEqual(allClients);
            Assert.AreEqual(true, allActualClients);
        }

        [Test]
        public void RepositoryUpdateClient()
        {            
            string expectedName = "John";
            string expectedSurname = "Wick";
            repo.UpdateClient(3, "John", "Wick");
            Assert.AreEqual(expectedName, repo.GetClient(3).Name);
            Assert.AreEqual(expectedSurname, repo.GetClient(3).Surname);
        }

        [Test]
        public void RepositoryAddRecord()
        {
            repoE.AddRecord(r);
            int expected = 1;
            Assert.AreEqual(expected, repoE.DataContext.records.Count);
        }

        [Test]
        public void RepositoryDeleteRecord()
        {
            int size = 20;
            repo.DeleteRecord(3);
            int expected = size - 1;
            int actual = repo.DataContext.records.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetRecord()
        {
            repoE.AddRecord(r);
            Assert.AreEqual(r, repoE.GetRecord(0));
        }

        [Test]
        public void RepositoryGetAllRecords()
        {
            List<Record> allRecords = (List<Record>)repo.GetAllRecords();
            List<Record> allActualRecords = (List<Record>)repo.DataContext.records.Values.ToList();
            bool actual = allActualRecords.SequenceEqual(allRecords);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecord()
        {
            string expectedAuthor = "Nirvana";
            string expectedTitle = "Nevermind";
            repo.UpdateRecord(5, "Nirvana", "Nevermind");
            Assert.AreEqual(expectedTitle, repo.GetRecord(5).Title);
            Assert.AreEqual(expectedAuthor, repo.GetRecord(5).Author);
        }

        [Test]
        public void RepositoryAddRecordStatus()
        {
            repo.AddRecordStatus(rs);
            Assert.AreEqual(rs, repo.GetRecordStatus(20));
        }

        [Test]
        public void RepositoryDeleteRecordStatus()
        {
            repo.DeleteRecordStatus(repo.GetRecordStatus(0));
            Assert.AreEqual(19, repo.DataContext.recordStatuses.Count);
        }

        [Test]
        public void RepositoryGetRecordStatus()
        {
            repo.AddRecordStatus(rs);
            RecordStatus actual = repo.GetRecordStatus(20);
            Assert.AreEqual(rs, actual);
        }

        [Test]
        public void RepositoryGetAllRecordStatuses()
        {
            List<RecordStatus> allStatuses = (List<RecordStatus>)repo.GetAllRecordStatus();
            bool actual = repo.DataContext.recordStatuses.SequenceEqual(allStatuses);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecordStatuses()
        {
            Record expectedRecord = new Record("A", "A");
            DateTime expectedPurchaseDate = DateTime.Today;
            repo.UpdateStatus(0, expectedRecord, expectedPurchaseDate);
            Record actualRec = repo.GetRecordStatus(0).Record;
            DateTime actualDate = repo.GetRecordStatus(0).DateOfPurchase;
            Assert.AreEqual(expectedRecord, actualRec);
            Assert.AreEqual(expectedPurchaseDate, repo.GetRecordStatus(0).DateOfPurchase);
        }

        [Test]
        public void RepositoryAddEvent()
        {
            repo.AddEvent(e);
            int expected = 20 + 1;
            int actual = repo.DataContext.events.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteEvent()
        {
            repo.EventDelete(repo.GetEvent(0));
            int actual = repo.DataContext.events.Count;
            Assert.AreEqual(19, actual);
        }

        [Test]
        public void RepositoryGetEvent()
        {
            repo.AddEvent(e);
            Assert.AreEqual(e, repo.GetEvent(20));
        }

        [Test]
        public void RepositoryGetAllEvents()
        {
            ObservableCollection<Event> allEvents = (ObservableCollection<Event>)repo.GetAllEvents();
            bool actual = repo.DataContext.events.SequenceEqual(allEvents);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateEvent()
        {
            Client expectedClient = new Client("Emily", "Johnson");
            Record expectedRecord = new Record("Sophia Martinez", "Dreamland Odyssey");
            DateTime expectedRentDate = DateTime.Parse("07-Apr-2023 08:30:00 AM");
            DateTime expectedDueDate = DateTime.Parse("14-Apr-2023 08:30:00 AM");
            repo.UpdateEvent(0, expectedClient, expectedRecord, expectedRentDate, expectedDueDate);
            Client actualClient = repo.GetEvent(0).MusicEnthusiast;
            Record actualRecord = repo.GetEvent(0).Record;
            DateTime actualRentDate = repo.GetEvent(0).PurchaseDate;
            DateTime actualDueDate = repo.GetEvent(0).ReturnDate;
            Assert.AreEqual(expectedClient, actualClient);
            Assert.AreEqual(expectedRecord, actualRecord);
            Assert.AreEqual(expectedRentDate, actualRentDate);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }

        [Test]
        public void ServiceFindEvent()
        {
            DataRepository repo1 = new DataRepository(new FillConstant());
            DataService serv = new DataService(repo1);
            Client c = new Client("Marek", "Kopania");
            serv.repo.AddClient(c);
            Event expected = new Event(serv.repo.GetRecord(0), c, DateTime.Now);
            serv.repo.AddEvent(expected);
            RecordStatus stat = new RecordStatus(serv.repo.GetRecord(0), DateTime.Now.AddDays(-15));
            serv.repo.AddRecordStatus(stat);
            Event actual = serv.FindEvent(c, stat);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ServiceEventsBetween()
        {
            DataRepository repo2 = new DataRepository(new FillConstant());
            DataService serv = new DataService(repo2);
            DateTime rentDate = new DateTime(2024, 01, 03);
            DateTime dueDate = new DateTime(2024, 01, 04);
            Client c1 = new Client("A", "A");
            Record r1 = new Record("B", "B");
            serv.repo.AddClient(c1);
            serv.repo.AddRecord(r1);
            Event e1 = new Event(r1, c1, rentDate, dueDate);
            serv.repo.AddEvent(e1);
            Assert.AreEqual(1, serv.EventsBetween(new DateTime(2024, 01, 01), new DateTime(2024, 01, 05)).Count());
            
        }

        [Test]
        public void ServiceAddEvent()
        {
            DataRepository reposi = new DataRepository(new FillConstant());
            DataService service = new DataService(reposi);    
            Event actual = service.AddEvent(service.repo.DataContext.clients[0], service.repo.DataContext.recordStatuses[0]); ;
            Assert.AreEqual(21, service.repo.DataContext.events.Count);
        }

        [Test]
        public void ServiceFindRecord()
        {
            DataRepository reposi = new DataRepository(new FillConstant());
            DataService service = new DataService(reposi);
            Assert.AreSame(service.repo.GetRecord(0), service.FindRecord(service.repo.GetRecordStatus(0)));
        }

        [Test]
        public void ServiceListAllClientEvents()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            DataService service = new DataService(repo);
            Client client = new Client("AAA", "BBB");
            service.repo.AddClient(client);
            Event e1 = new Event(service.repo.GetRecord(0), client, DateTime.Today.AddDays(-2));
            service.repo.AddEvent(e1);
            ObservableCollection<Event> events = (ObservableCollection<Event>)service.ListAllClientEvents(client);
            int expected = 1;
            int actual = events.Count;
            Assert.AreEqual(expected, actual);
        }
        
    }
}
