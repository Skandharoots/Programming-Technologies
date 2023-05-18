using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTest
{
    internal class EventModelMOCK : IEventModel
    {
        internal EventModelMOCK(IEventCRUD service = null)
        {
            Service = service ?? IEventCRUD.Create();
        }
        public IEventCRUD Service { get; }

        public IEnumerable<IEventModelData> Events
        {
            get;
            
        }

        public void Add(int id, int clientId, int statusId, DateTime time)
        {
            Service.AddEvent(id, clientId, statusId, time);
        }

        public void Delete(int id)
        {
            Service.DeleteEvent(id);
        }

        public void UpdateClient(int id, int clientId)
        {
            Service.UpdateEventClient(id, clientId);
        }

        public void UpdateStatus(int id, int statusId)
        {
            Service.UpdateEventRecord(id, statusId);
        }

        public void UpdatePurchaseDate(int id, DateTime time)
        {
            Service.UpdateEventPurchaseDate(id, time);
        }
    }
}
