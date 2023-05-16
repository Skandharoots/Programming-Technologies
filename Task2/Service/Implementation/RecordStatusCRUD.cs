using Data.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class RecordStatusCRUD : IRecordStatusCRUD
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

        public void AddRecordStatus(int id, int recordId, bool sold)
        {
            dataLayer.AddRecordStatus(id, recordId, sold);
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

        public IRecordStatusDTO GetRecordStatus(int id)
        {
            return Map(dataLayer.GetRecordStatus(id));
        }

        public IEnumerable<IRecordStatusDTO> GetAllRecordStatuses()
        {
            var statuses = dataLayer.GetAllRecordStatuses();
            var result = new List<IRecordStatusDTO>();

            foreach (var staus in statuses)
                result.Add(Map(staus));
            return result;
        }
    }
}
