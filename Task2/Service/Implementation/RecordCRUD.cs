using Data.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class RecordCRUD : IRecordCRUD
    {

        private DataLayerAPI dataLayer;

        public RecordCRUD()
        {
            dataLayer = DataLayerAPI.CreateLayer();
        }

        public RecordCRUD(DataLayerAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        private RecordDTO Map(IRecord record)
        {
            if (record == null)
                return null;
            return new RecordDTO(record.Id, record.Author, record.Title);
        }


        public void AddRecord(int id, string author, string title)
        {
            dataLayer.AddRecord(id, author, title);
        }

        public void DeleteRecord(int id)
        {
            dataLayer.DeleteRecord(id);
        }


        public void UpdateAuthor(int id, string author)
        {
            dataLayer.UpdateRecordAuthor(id, author);
        }

        public void UpdateTitle(int id, string title)
        {
            dataLayer.UpdateRecordTitle(id, title);
        }


        public IRecordDTO GetRecord(int id)
        {
            return Map(dataLayer.GetRecord(id));
        }

        public IEnumerable<IRecordDTO> GetAllRecords()
        {

            var records = dataLayer.GetAllRecords();
            var result = new List<IRecordDTO>();

            foreach (var record in records)
                result.Add(Map(record));

            return result;
        }
    }
}
