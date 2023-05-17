using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.Implementation;

namespace Service.API
{
    public abstract class IClientCRUD
    {
        public abstract void AddClient(int id, string name, string surname);

        public abstract void DeleteClient(int id);
        public abstract void UpdateClientName(int id, string name);
        public abstract void UpdateClientSurname(int id, string surname);
        public abstract IClientDTO GetClient(int id);
        public abstract IEnumerable<IClientDTO> GetAllClients();

        public static IClientCRUD Create()
        {
            return new ClientCRUD();
        }

        public static IClientCRUD Create(DataLayerAPI layer) 
        { 
            return new ClientCRUD(layer); 
        }


    }
}
