using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Service.Implementation;
using Presentation.Model.API;

namespace Presentation.Model
{
    internal class ClientModel : IClientModel
    {
        internal ClientModel(IClientCRUD service = null)
        {
            Service = service ?? new ClientCRUD();
        }

        public IClientCRUD Service { get; }

        private ClientModelData Map(IClientDTO client)
        {
            return client == null ? null : new ClientModelData(client.Id, client.Name, client.Surname);
        }

        public IEnumerable<IClientModelData> Clients
        {
            get
            {
                List<IClientModelData> users = new List<IClientModelData>();
                var clients = Service.GetAllClients();
                
                foreach (var c in clients)
                {
                    users.Add(Map(c));
                }
                 return users;
            }
        }

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

        public void UpdateSurname(int id, string surname)
        {
             Service.UpdateClientSurname(id, surname);
        }
    }
}
