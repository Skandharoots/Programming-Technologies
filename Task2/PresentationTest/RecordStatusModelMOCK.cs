using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTest
{
    internal class RecordStatusModelMOCK : IRecordStatusModel
    {
        internal RecordStatusModelMOCK(IRecordStatusCRUD service = null)
        {
            Service = service ?? IRecordStatusCRUD.Create();
        }

        public IRecordStatusCRUD Service { get; }


        public IEnumerable<IRecordStatusModelData> Statuses
        {
            get; 
        }

        public void Add(int id, int recordId, bool sold)
        {
            Service.AddRecordStatus(id, recordId, sold);
        }

        public void Delete(int id)
        {
            Service.DeleteRecordStatus(id);
        }

        public void UpdateRecord(int id, int recordId)
        {
            Service.UpdateRecordStatusRecordId(id, recordId);
        }

        public void UpdateSold(int id, bool sold)
        {
            Service.UpdateRecordStatusSold(id, sold);
        }
    }
}
