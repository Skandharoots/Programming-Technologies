using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.Implementation
{
    internal class Return : IEvent
    {
        public IClient client { get; set; }

        public IRecordStatus status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Return(IClient client, IRecordStatus status, DateTime returnDate = default)
        {
            this.client = client;
            this.status = status;
            ReturnDate = returnDate;
        }
    }
}
