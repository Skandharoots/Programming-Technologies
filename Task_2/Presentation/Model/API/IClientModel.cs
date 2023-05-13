using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model.API
{
    public interface IClientModel
    {
        IClientCRUD Service { get; }
        IEnumerable<IClientModelData> Clients { get;}
        void Add(int id, string name, string surname);
        void Delete(int id);
        void UpdateClient(int id, string name, string surname);
        
    }
}
