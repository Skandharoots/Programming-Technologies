using Data.API;
using Service.CRUD;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public abstract class IRecordCRUD
    {
        public abstract void AddRecord(string author, string title);
        public abstract void DeleteRecord(int id);
        public abstract void UpdateAuthor(int id, string author);
        public abstract void UpdateTitle(int id, string title);
        public abstract IRecordDTO GetRecord(int id);
        public abstract IEnumerable<IRecordDTO> GetAllRecords();

        public static IRecordCRUD CreateRecord(DataLayerAPI dataLayer)
        {
            return new RecordCRUD(dataLayer);
        }
    }
}
