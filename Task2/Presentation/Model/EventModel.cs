using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;
using Service.API;
using Service.Implementation;

namespace Presentation.Model
{
    internal class EventModel : IEventModel
    {
        internal EventModel(IEventCRUD service = null)
        {
            Service = service ?? IEventCRUD.Create();
        }

        public IEventCRUD Service { get; }

        private EventModelData Map(IEventDTO events)
        {
            return events == null ? null : new EventModelData(events.Id, events.ClientId, events.RecordId, events.PurchaseDate);
        }

        public IEnumerable<IEventModelData> Events
        {
            get
            {
                List<IEventModelData> events = new List<IEventModelData>();
                var eventss = Service.GetAllEvents();

                foreach (var c in eventss)
                {
                    events.Add(Map(c));
                }
                return events;
            }
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

