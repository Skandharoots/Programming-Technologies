using Data.API;
using Service.CRUD;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public abstract class IClientCRUD
    {
        public abstract void AddClient(string name, string surname);

        public abstract void DeleteClient(int id);
        public abstract void UpdateClientName(int id, string name);
        public abstract void UpdateClientSurname(int id, string surname);
        public abstract IClientDTO GetClient(int id);
        public abstract IEnumerable<IClientDTO> GetAllClients();

        public static IClientCRUD CreateClient(DataLayerAPI dataLayer)
        {
            return new ClientCRUD(dataLayer);
        }

        public static IClientCRUD Create()
        { 
            return new ClientCRUD(); 
        }

    }
}
