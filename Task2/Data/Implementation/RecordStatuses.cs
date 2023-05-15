using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.Implementation
{
    internal class RecordStatuses : IRecordStatus
    {
        public int Id { get; set; }
        public int RecordId { get; set; }
        public bool Sold { get; set; }

        public RecordStatuses(int id, int recordId, bool sold)
        {
            Id = id;
            RecordId = recordId;
            Sold = sold;
        }
    }
}
