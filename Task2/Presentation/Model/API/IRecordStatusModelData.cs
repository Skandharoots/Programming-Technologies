using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IRecordStatusModelData
    {
        int Id { get; set; }
        int RecordId { get; set; }
        bool Sold { get; set; }
    }
}
