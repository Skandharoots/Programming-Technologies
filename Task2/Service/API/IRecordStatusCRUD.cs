using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Implementation;

namespace Service.API
{
    public interface IRecordStatusCRUD
    {
        void AddRecordStatus(int recordId, bool sold);
        void DeleteRecordStatus(int recordStatusId);
        void UpdateRecordStatusRecordId(int id, int recordId);
        void UpdateRecordStatusSold(int id, bool sold);
        RecordStatusDTO GetRecordStatus(int id);
        IEnumerable<RecordStatusDTO> GetAllRecordStatuses();


    }
}
