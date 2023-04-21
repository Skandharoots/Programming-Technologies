using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API {

    public interface IEvent {

        int RecordId { get; set; }
        DateTime PurchaseDate { get; set; }
        DateTime ReturnDate { get; set; }
    }
}
