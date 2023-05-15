using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Implementation;

namespace Service.API
{
    public interface IRecordStatusDTO
    {
        int Id { get; set; }
        int RecordId { get; set; }
        bool Sold { get; set; }
    }
}
