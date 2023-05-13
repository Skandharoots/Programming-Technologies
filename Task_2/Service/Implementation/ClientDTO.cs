using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Service.Implementation
{
    public class ClientDTO : IClientDTO
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Surname { get; set; }

        public ClientDTO(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
