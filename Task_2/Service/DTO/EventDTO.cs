using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RecordId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
