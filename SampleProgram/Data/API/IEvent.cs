using Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API {

    public interface IEvent {

        enum Eventkind {rent, ret}
        IClient client { get; set; }
        IRecordStatus status { get; set; }
        DateTime PurchaseDate { get; set; }
        DateTime ReturnDate { get; set; }

        static IEvent CreateEvent(Eventkind kind, IClient client, IRecordStatus status)
        {
            switch (kind)
            {
                case Eventkind.rent:
                    return new Rent(client, status, DateTime.Now, DateTime.Now.AddDays(10));
                    
                case Eventkind.ret:
                    return new Return(client, status, DateTime.Now);
            }
            return null;
        }
    }
}
