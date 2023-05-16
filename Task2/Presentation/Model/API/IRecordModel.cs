using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IRecordModel
    {
        IRecordCRUD Service { get; }
        IEnumerable<IRecordModelData> Records { get; }
        void Add(int id, string author, string title);
        void Delete(int id);
        void UpdateAuthor(int id, string author);
        void UpdateTitle(int id, string title);
    }
}
