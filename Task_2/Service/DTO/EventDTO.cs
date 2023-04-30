using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class EventDTO
    {
        int Id { get; set; }
        int ClientId { get; set; }
        int RecordId { get; set; }
        DateTime PurchaseDate { get; set; }
    }
}
