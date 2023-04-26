using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;
using System.Collections.Generic;
using NSubstitute;

namespace TestLibrary {

    internal class LogicLayerTest {
        
        
        private IClient c;
        private IRecord r;
        private IRecordStatus rs;
        private IEvent e;
        
        [SetUp]
        public void SetUp() {
            c = new Client("Mateusz", "Kubiak");
            r = new Record(30, "Nevermind", "Nirvana");
            rs = new RecordStatus(true, r, DateTime.Today);
            e = new Rent(c, rs, DateTime.Now, DateTime.Now.AddHours(5));
        }
        
        [Test]
        public void ServiceFindEvent() {
            var repo = IDataRepository.CreateRepo();
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            IEvent expected = new Rent(serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0), DateTime.Now);
            serv.GetRepo().AddEvent(expected);
            IRecordStatus stat = new RecordStatus(true, serv.GetRepo().GetRecord(0), DateTime.Now.AddDays(-15));
            serv.GetRepo().AddRecordStatus(stat);
            IEvent actual = serv.FindEvent(stat);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ServiceEventsBetween() {
            var repo2 = IDataRepository.CreateRepo();
            var serv = IDataService.CreateService(repo2);

            DateTime rentDate = new DateTime(2024, 01, 03);
            DateTime dueDate = new DateTime(2024, 01, 04);

            IClient c1 = new Client("A", "A");
            IRecord r1 = new Record(100, "B", "B");
            IRecordStatus s1 = new RecordStatus(true, r1, DateTime.Now);
            serv.GetRepo().AddClient(c1);
            serv.GetRepo().AddRecord(r1);
            serv.GetRepo().AddRecordStatus(s1);
            
            Rent e1 = new Rent(c1, s1, rentDate, dueDate);
            serv.GetRepo().AddEvent(e1);
            
            Assert.AreEqual(1, serv.EventsBetween(new DateTime(2024, 01, 01), new DateTime(2024, 01, 05)).Count());
        }
        
        [Test]
        public void ServiceFindRecord() {
            var repo = IDataRepository.CreateRepo();
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            var serv = IDataService.CreateService(repo);
            Assert.AreSame(serv.GetRepo().GetRecord(0), serv.FindRecord(serv.GetRepo().GetRecordStatus(0)));
        }

        [Test]
        public void ServiceFindCustomerEvent()
        {
            var repo = IDataRepository.CreateRepo();
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            Assert.AreEqual(e, serv.FindClientEvent(c));
        }

        [Test]

        public void ServiceRentRecord()
        {
            var repo = IDataRepository.CreateRepo();
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            var serv = IDataService.CreateService(repo);
            serv.RentRecord(serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0));
            Assert.False(serv.GetRepo().GetRecordStatus(0).available);
        }

        [Test]

        public void ServiceReturnRecord()
        {
            var repo = IDataRepository.CreateRepo();
            repo.AddClient(c);
            repo.AddRecord(r);
            IRecordStatus stat = new RecordStatus(false, repo.GetRecord(0), DateTime.Now);
            repo.AddRecordStatus(stat);
            var serv = IDataService.CreateService(repo);
            serv.ReturnRecord(serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0));
            Assert.True(serv.GetRepo().GetEvent(0).status.available);
        }

    }
   
}
