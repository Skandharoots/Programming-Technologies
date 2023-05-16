using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;
using Service.API;
using Service.Implementation;

namespace PresentationTest
{
    internal class ClientModelMOCK : IClientModel
    {
        internal ClientModelMOCK(IClientCRUD service = null)
        {
            Service = service ?? new ClientCRUD();
            Clients = new List<IClientModelData>();
        }

        public IClientCRUD Service { get; }

        public IEnumerable<IClientModelData> Clients { get; }

        public void Add(int id, string name, string surname)
        {
            Service.AddClient(id, name, surname);
        }

        public void Delete(int id)
        {
            Service.DeleteClient(id);     
        }

        public void UpdateName(int id, string name)
        {
            Service.UpdateClientName(id, name);
            
        }

        public void UpdateSurname(int id , string surname)
        {
            Service.UpdateClientSurname(id, surname);
        }
    }
}
