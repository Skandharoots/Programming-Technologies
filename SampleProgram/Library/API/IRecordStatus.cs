using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IRecordStatus
    {
        DateTime DateOfPurchase { get; set; }
        IRecord Record { get; set; }
    }
}
