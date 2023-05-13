using Data.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IRecordStatusCRUD
    {
        void AddRecordStatus(int recordId, bool sold);
        void DeleteRecordStatus(int recordStatusId);
        void UpdateRecordStatusRecordId(int id, int recordId);
        void UpdateRecordStatusSold(int id, bool sold);
        IRecordStatusDTO GetRecordStatus(int id);
        IEnumerable<IRecordStatusDTO> GetAllRecordStatuses();

       
    }
}
