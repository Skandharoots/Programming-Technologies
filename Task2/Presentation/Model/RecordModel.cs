using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;
using Service.API;
using Service.Implementation;

namespace Presentation.Model
{
    internal class RecordModel : IRecordModel
    {
        internal RecordModel(IRecordCRUD service = null)
        {
            Service = service ?? new RecordCRUD();
        }

        public IRecordCRUD Service { get; }

        private RecordModelData Map(IRecordDTO client)
        {
            return client == null ? null : new RecordModelData(client.Id, client.Author, client.Title);
        }

        public IEnumerable<IRecordModelData> Records
        {
            get
            {
                List<IRecordModelData> records = new List<IRecordModelData>();
                var record = Service.GetAllRecords();

                foreach (var c in record)
                {
                    records.Add(Map(c));
                }
                return records;
            }
        }

        public void Add(int id, string author, string title)
        {
            Service.AddRecord(id, author, title);
        }

        public void Delete(int id)
        {
            Service.DeleteRecord(id);
        }

        public void UpdateAuthor(int id, string author)
        {
            Service.UpdateAuthor(id, author);
        }

        public void UpdateTitle(int id, string title)
        {
            Service.UpdateTitle(id, title);
        }
    }
}

