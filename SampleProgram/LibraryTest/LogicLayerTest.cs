using Data.Implementation;
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
        /*private DataRepository repo;
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
        */
        

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

        [Test]
        public void ServiceListAllRecords()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            DataService service = new DataService(repo);
            List<Record> expected = new List<Record>();
            expected.AddRange(service.repo.GetAllRecords());
            Assert.AreEqual(expected, service.ListAllRecords());
        }

        [Test]
        public void ServiceListAllStatus()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            DataService service = new DataService(repo);
            List<RecordStatus> expected = new List<RecordStatus>();
            expected.AddRange(service.repo.GetAllRecordStatus());
            Assert.AreEqual(expected, service.ListAllStatus());
        }

        [Test]
        public void ServiceListAllEvents()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            DataService service = new DataService(repo);
            List<Event> expected = new List<Event>();
            expected.AddRange(service.repo.GetAllEvents());
            Assert.AreEqual(expected, service.ListAllEvents());
        }

        [Test]
        public void ServiceListAllClients()
        {
            DataRepository repo = new DataRepository(new FillConstant());
            DataService service = new DataService(repo);
            List<Client> expected = new List<Client>();
            expected.AddRange(service.repo.GetAllClients());
            Assert.AreEqual(expected, service.ListAllClients());
        }
    }
}
