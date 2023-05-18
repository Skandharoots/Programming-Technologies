using Presentation.Model.API;
using Service.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    internal class RecordStatusModel : IRecordStatusModel
    {
        internal RecordStatusModel(IRecordStatusCRUD service = null)
        {
            Service = service ?? IRecordStatusCRUD.Create();
        }

        public IRecordStatusCRUD Service { get; }

        private RecordStatusModelData Map(IRecordStatusDTO client)
        {
            return client == null ? null : new RecordStatusModelData(client.Id, client.RecordId, client.Sold);
        }

        public IEnumerable<IRecordStatusModelData> Statuses
        {
            get
            {
                List<IRecordStatusModelData> users = new List<IRecordStatusModelData>();
                var clients = Service.GetAllRecordStatuses();

                foreach (var c in clients)
                {
                    users.Add(Map(c));
                }
                return users;
            }
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

