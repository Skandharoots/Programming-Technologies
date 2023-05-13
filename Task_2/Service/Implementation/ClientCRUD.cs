using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;

namespace Service.Implementation
{
    public class ClientCRUD : IClientCRUD
    {
        private DataLayerAPI dataLayer;

        public ClientCRUD()
        {
            dataLayer = DataLayerAPI.CreateLayer();
        }

        public ClientCRUD(DataLayerAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        private ClientDTO Map(IClient client)
        {
            if (client == null)
            {
                return null;
            }

            return new ClientDTO(client.Id, client.Name, client.Surname);
            
        }

        public void AddClient(string name, string surname)
        {
            dataLayer.AddClient(name, surname);
        }

        public void DeleteClient(int id)
        {
            dataLayer.DeleteClient(id);
        }

        public void UpdateClientName(int id, string name)
        {
            dataLayer.UpdateClientName(id, name);
        }

        public void UpdateClientSurname(int id, string surname)
        {
            dataLayer.UpdateClientSurname(id, surname);
        }

        public IClientDTO GetClient(int id)
        {
            return Map(dataLayer.GetClient(id));
        }

        public IEnumerable<IClientDTO> GetAllClients()
        {
            var clients = dataLayer.GetAllClients();
            var result = new List<IClientDTO>();

            foreach (var client in clients)
            {
                result.Add(Map(client));
            }

            return result;
        }
    }
}
