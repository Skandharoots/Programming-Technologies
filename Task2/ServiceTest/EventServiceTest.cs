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
    public class EventServiceTest
    {
        [TestMethod]
        public void TestAddDeleteEvent()
        {
            IEventCRUD eventService = new EventCRUD(new DataLayerMock());
            eventService.AddEvent(1, 3, DateTime.Now);
            Assert.IsNotNull(eventService.GetEvent(1));
            eventService.DeleteEvent(1);

        }

        [TestMethod]
        public void TestUpdateEvent()
        {
            IEventCRUD eventService = new EventCRUD(new DataLayerMock());
            eventService.AddEvent(1, 3, DateTime.Now);
            eventService.UpdateEventClient(1, 2);
            Assert.AreEqual(eventService.GetEvent(1).ClientId, 2);
            eventService.UpdateEventRecord(1, 6);
            Assert.AreEqual(eventService.GetEvent(1).RecordId, 6);
            eventService.DeleteEvent(1);
        }

        [TestMethod]
        public void TestGetAllEvents()
        {
            IEventCRUD eventService = new EventCRUD(new DataLayerMock());
            eventService.AddEvent(1, 3, DateTime.Now);
            Assert.AreEqual(1, eventService.GetAllEvents().Count());
        }
    }
}
