using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;

namespace Presentation.Model
{
    internal class RecordStatusModelData : IRecordStatusModelData
    {
        public int Id { get; set; }
        public int RecordId { get; set; }
        public bool Sold { get; set; }

        public RecordStatusModelData(int id, int recordId, bool sold)
        {
            Id = id;
            RecordId = recordId;
            Sold = sold;
        }
    }
}
