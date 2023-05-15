using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    internal class Events : IEvent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RecordId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Events(int id, int userId, int productId)
        {
            Id = id;
            ClientId = userId;
            RecordId = productId;
            PurchaseDate = DateTime.Now;
        }
    }
}
