using Data.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class EventCRUD : IEventCRUD
    {

        private DataLayerAPI dataLayer;

        public EventCRUD()
        {
            dataLayer = DataLayerAPI.CreateLayer();
        }

        public EventCRUD(DataLayerAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        private EventDTO Map(IEvent ev)
        {
            if (ev == null)
                return null;
            return new EventDTO(ev.Id, ev.ClientId, ev.RecordId, ev.PurchaseDate);
        }


        public void AddEvent(int clientId, int productId, DateTime purchaseDate)
        {
            dataLayer.AddEvent(clientId, productId, purchaseDate);
        }

        public void DeleteEvent(int id)
        {
            dataLayer.DeleteEvent(id);
        }


        public void UpdateEventClient(int id, int clientId)
        {
            dataLayer.UpdateEventClient(id, clientId);
        }

        public void UpdateEventRecord(int id, int recordId)
        {
            dataLayer.UpdateEventRecord(id, recordId);
        }

        public void UpdateEventPurchaseDate(int id, DateTime purchaseDate)
        {
            dataLayer.UpdateEventPurchaseDate(id, purchaseDate);
        }


        public IEventDTO GetEvent(int id)
        {
            return Map(dataLayer.GetEvent(id));
        }

        public IEnumerable<IEventDTO> GetAllEvents()
        {

            var events = dataLayer.GetAllEvents();
            var result = new List<IEventDTO>();

            foreach (var _event in events)
                result.Add(Map(_event));

            return result;
        }
    }
}
