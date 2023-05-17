using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.Implementation;

namespace Service.API
{
    public abstract class IRecordStatusCRUD
    {
        public abstract void AddRecordStatus(int id, int recordId, bool sold);
        public abstract void DeleteRecordStatus(int recordStatusId);
        public abstract void UpdateRecordStatusRecordId(int id, int recordId);
        public abstract void UpdateRecordStatusSold(int id, bool sold);
        public abstract IRecordStatusDTO GetRecordStatus(int id);
        public abstract IEnumerable<IRecordStatusDTO> GetAllRecordStatuses();

        public static IRecordStatusCRUD Create()
        {
            return new RecordStatusCRUD();
        }

        public static IRecordStatusCRUD Create(DataLayerAPI layer)
        { 
            return new RecordStatusCRUD(layer);
        }

    }
}
