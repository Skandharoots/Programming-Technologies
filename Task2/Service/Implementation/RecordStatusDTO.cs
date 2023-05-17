using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    internal class RecordStatusDTO : IRecordStatusDTO
    {
        public int Id { get; set; }
        public int RecordId { get; set; }
        public bool Sold { get; set; }
        public RecordStatusDTO(int id, int recordId, bool sold)
        {
            Id = id;
            RecordId = recordId;
            Sold = sold;
        }
    }
}
