using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IEventModel
    {
        IEventCRUD Service { get; }
        IEnumerable<IEventModelData> Events { get; }
        void Add(int id, int clientId, int statusId, DateTime time);
        void Delete(int id);
        void UpdateClient(int id, int clientId);
        void UpdateStatus(int id, int statusId);
        void UpdatePurchaseDate(int id, DateTime time);
    }
}
