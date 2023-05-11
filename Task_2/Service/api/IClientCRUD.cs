using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IClientCRUD
    {
        void AddClient(string name, string surname);

        void DeleteClient(string name);
        void UpdateClientName(int id, string name);
        void UpdateClientSurname(int id , string surname);
        ClientDTO GetClient(int id);
        IEnumerable<ClientDTO> GetAllClients();

    }
}
