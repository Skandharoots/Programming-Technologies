using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;

namespace Presentation.Model
{
    internal class EventModelData : IEventModelData
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public EventModelData(int id, int clientId, int statusId, DateTime purchaseDate)
        {
            Id = id;
            ClientId = clientId;
            StatusId = statusId;
            PurchaseDate = purchaseDate;
        }
    }
}
