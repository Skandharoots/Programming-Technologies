using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.Implementation;

namespace Service.API
{
    public abstract class IRecordCRUD
    {
        public abstract void AddRecord(int id, string author, string title);
        public abstract void DeleteRecord(int id);
        public abstract void UpdateAuthor(int id, string author);
        public abstract void UpdateTitle(int id, string title);
        public abstract IRecordDTO GetRecord(int id);
        public abstract IEnumerable<IRecordDTO> GetAllRecords();

        public static IRecordCRUD Create()
        {
            return new RecordCRUD();
        }

        public static IRecordCRUD Create(DataLayerAPI layer) 
        {
            return new RecordCRUD(layer);
        }
    }
}
