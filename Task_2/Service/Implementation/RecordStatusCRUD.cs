using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class RecordStatusCRUD
    {
        private DataLayerAPI dataLayer;

        public RecordStatusCRUD()
        {
            dataLayer = DataLayerAPI.CreateLayer();
        }

        public RecordStatusCRUD(DataLayerAPI dataLayer) 
        {
            this.dataLayer = dataLayer;
        }

        private RecordStatusDTO Map(IRecordStatus recordStatus)
        {
            if (recordStatus == null)
                return null;
            return new RecordStatusDTO(recordStatus.Id, recordStatus.RecordId, recordStatus.Sold);
        }

        public void AddRecordStatus(int recordId, bool sold)
        {
            dataLayer.AddRecordStatus(recordId, sold);
        }

        public void DeleteRecordStatus(int recordStatusId) 
        {
            dataLayer.DeleteRecordStatus(recordStatusId);
        }

        public void UpdateRecordStatusRecordId(int id, int recordId)
        {
            dataLayer.UpdateRecordStatusRecord(id, recordId);
        }

        public void UpdateRecordStatusSold(int id, bool sold)
        {
            dataLayer.UpdateRecordStatusSold(id, sold);
        }

        public RecordStatusDTO GetRecordStatus(int id) 
        {
            return Map(dataLayer.GetRecordStatus(id));
        }

        public IEnumerable<RecordStatusDTO> GetAllRecordStatuses()
        {
            var statuses = dataLayer.GetAllRecordStatuses();
            var result = new List<RecordStatusDTO>();

            foreach (var staus in statuses)
                result.Add(Map(staus));
            return result;
        }
    }
}
