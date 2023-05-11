using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Service.DTO
{
    internal class EventDTO : IEventDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RecordId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public EventDTO(int id, int clientId, int recordId, DateTime purchaseDate)
        {
            Id = id;
            ClientId = clientId;
            RecordId = recordId;
            PurchaseDate = purchaseDate;
        }
    }
}
