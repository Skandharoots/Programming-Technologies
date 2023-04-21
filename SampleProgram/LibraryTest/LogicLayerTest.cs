﻿using Data.Implementation;
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
        }
        
        [Test]
        public void ServiceFindEvent() {
            var repo = IDataRepository.CreateConstantRepo(new FillConstant());
            var serv = IDataService.CreateService(repo);
            IEvent expected = new Event(serv.GetRepo().GetRecord(0).Id, DateTime.Now);
            serv.GetRepo().AddEvent(expected);
            IRecordStatus stat = new RecordStatus(serv.GetRepo().GetRecord(0), DateTime.Now.AddDays(-15));
            serv.GetRepo().AddRecordStatus(stat);
            IEvent actual = serv.FindEvent(stat);
            Assert.AreEqual(expected, actual);
        }
        /*
        [Test]
        public void ServiceEventsBetween() {
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
        public void ServiceAddEvent() {
            DataRepository reposi = new DataRepository(new FillConstant());
            DataService service = new DataService(reposi);    
            Event actual = service.AddEvent(service.repo.DataContext.clients[0], service.repo.DataContext.recordStatuses[0]); ;
            Assert.AreEqual(21, service.repo.DataContext.events.Count);
        }

        [Test]
        public void ServiceFindRecord() {
            DataRepository reposi = new DataRepository(new FillConstant());
            DataService service = new DataService(reposi);
            Assert.AreSame(service.repo.GetRecord(0), service.FindRecord(service.repo.GetRecordStatus(0)));
        }*/

    }

}
