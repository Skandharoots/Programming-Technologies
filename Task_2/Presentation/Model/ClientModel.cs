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
    internal class ClientModel : IClientModel
    {
        public IClientCRUD Service { get; }

        internal ClientModel(IClientCRUD service = null)
        {
            Service = service ?? new ClientCRUD();
        }

        public IEnumerable<IClientModelData> Clients
        {
            get
            {
                List<IClientModelData> clients = new List<IClientModelData>();
                foreach (var c in Service.GetAllClients())
                {
                    clients.Add(new ClientModelData(c.Id, c.Name, c.Surname));
                }
                return clients;
            }
        }

        public void Add(int id, string name, string surname)
        {
            Service.AddClient(name, surname);
        }

        public void Delete(int id)
        {
            Service.DeleteClient(id);
        }

        public void UpdateClient(int id, string name, string surname)
        {
            Service.UpdateClientName(id, name);
            Service.UpdateClientSurname(id, surname);
        }

    }
}
