using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API {

    public interface IRecordStatus {

        IRecord record { get; set; }
        bool available { get; set; }
        DateTime DateOfPurchase { get; set; }
    }
}
