using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Implementation;

namespace Service.API
{
    public interface IEventCRUD
    {
        void AddEvent(int clientId, int recordId, DateTime purchaseDate);
        void DeleteEvent(int id);
        void UpdateEventClient(int id, int clientId);
        void UpdateEventRecord(int id, int recordId);
        void UpdateEventPurchaseDate(int id, DateTime purchaseDate);
        IEventDTO GetEvent(int id);
        IEnumerable<IEventDTO> GetAllEvents();



    }
}
