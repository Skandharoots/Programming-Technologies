using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IRecordStatus
    {
        int Id { get; set; }
        int RecordId { get; set; }
        bool Sold { get; set; }
    }
}
