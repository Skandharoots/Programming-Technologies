using Data.Implementation;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Logic.API;
using Logic.Implementation;

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
            rs = new RecordStatus(r, DateTime.Today);
            e = new Event(c, rs, DateTime.Now, DateTime.Now.AddHours(5));
        }
        
        [Test]
        public void ServiceFindEvent() {
            var repo = IDataRepository.CreateRepo();
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            IEvent expected = new Event(serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0), DateTime.Now);
            serv.GetRepo().AddEvent(expected);
            IRecordStatus stat = new RecordStatus(serv.GetRepo().GetRecord(0), DateTime.Now.AddDays(-15));
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
            IRecordStatus s1 = new RecordStatus(r1, DateTime.Now);
            serv.GetRepo().AddClient(c1);
            serv.GetRepo().AddRecord(r1);
            serv.GetRepo().AddRecordStatus(s1);
            
            Event e1 = new Event(c1, s1, rentDate, dueDate);
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

    }
   
}
