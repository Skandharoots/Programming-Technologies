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


        public void AddRecord(string author, string title)
        {
            dataLayer.AddRecord(author, title);
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


        public RecordDTO GetRecord(int id)
        {
            return Map(dataLayer.GetRecord(id));
        }

        public IEnumerable<RecordDTO> GetAllRecords()
        {

            var records = dataLayer.GetAllRecords();
            var result = new List<RecordDTO>();

            foreach (var record in records)
                result.Add(Map(record));

            return result;
        }
    }
}
