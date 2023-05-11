using Data.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public abstract class IRecordStatusCRUD
    {
        public abstract void AddRecordStatus(int recordId, bool sold);
        public abstract void DeleteRecordStatus(int recordStatusId);
        public abstract void UpdateRecordStatusRecordId(int id, int recordId);
        public abstract void UpdateRecordStatusSold(int id, bool sold);
        public abstract IRecordStatusDTO GetRecordStatus(int id);
        public abstract IEnumerable<IRecordStatusDTO> GetAllRecordStatuses();

        public IRecordStatusCRUD CreateRecordStatus(DataLayerAPI dataLayer)
        {
            return new RecordStatusCRUD(dataLayer);
        }
    }
}
