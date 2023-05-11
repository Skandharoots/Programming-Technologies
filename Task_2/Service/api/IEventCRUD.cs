using Data.API;
using Service.CRUD;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public abstract class IEventCRUD
    {
        public abstract void AddEvent(int clientId, int recordId, DateTime purchaseDate);
        public abstract void DeleteEvent(int id);
        public abstract void UpdateEventClient(int id, int clientId);
        public abstract void UpdateEventRecord(int id, int recordId);
        public abstract void UpdateEventPurchaseDate(int id, DateTime purchaseDate);
        public abstract IEventDTO GetEvent(int id);
        public abstract IEnumerable<IEventDTO> GetAllEvents();

        public static IEventCRUD CreateEvent(DataLayerAPI dataLayer)
        {
            return new EventCRUD(dataLayer);
        }

    }
}
