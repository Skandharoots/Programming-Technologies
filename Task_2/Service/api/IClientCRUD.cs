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

        void DeleteClient(int id);
        void UpdateClientName(int id, string name);
        void UpdateClientSurname(int id , string surname);
        IClientDTO GetClient(int id);
        IEnumerable<IClientDTO> GetAllClients();

    }
}
