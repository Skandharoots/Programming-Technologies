using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.Implementation;

namespace Service.API
{
    public abstract class IEventCRUD
    {
        public abstract void AddEvent(int id, int clientId, int recordId, DateTime purchaseDate);
        public abstract void DeleteEvent(int id);
        public abstract void UpdateEventClient(int id, int clientId);
        public abstract void UpdateEventRecord(int id, int recordId);
        public abstract void UpdateEventPurchaseDate(int id, DateTime purchaseDate);
        public abstract IEventDTO GetEvent(int id);
        public abstract IEnumerable<IEventDTO> GetAllEvents();

        public static IEventCRUD Create() { return new EventCRUD(); }

        public static IEventCRUD Create(DataLayerAPI layer)
        {
            return new EventCRUD(layer);
        }

    }
}
