using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model;

namespace PresentationTest
{
    internal class RecordModelMOCK : IRecordModel
    {
        internal RecordModelMOCK(IRecordCRUD service = null)
        {
            Service = service ?? IRecordCRUD.Create();
        }
        public IRecordCRUD Service { get; }

        public IEnumerable<IRecordModelData> Records
        {
            get;
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

