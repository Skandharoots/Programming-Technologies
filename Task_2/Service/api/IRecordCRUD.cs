using Data.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IRecordCRUD
    {
       void AddRecord(string author, string title);
       void DeleteRecord(int id);
       void UpdateAuthor(int id, string author);
       void UpdateTitle(int id, string title);
       IRecordDTO GetRecord(int id);
       IEnumerable<IRecordDTO> GetAllRecords();

        
    }
}
