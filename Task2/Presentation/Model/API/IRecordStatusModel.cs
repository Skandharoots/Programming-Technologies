using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IRecordStatusModel
    {
        IRecordStatusCRUD Service { get; }
        IEnumerable<IRecordStatusModelData> Statuses { get; }
        void Add(int id, int recordId, bool sold);
        void Delete(int id);
        void UpdateRecord(int id, int recordId);
        void UpdateSold(int id, bool sold);
    }
}
