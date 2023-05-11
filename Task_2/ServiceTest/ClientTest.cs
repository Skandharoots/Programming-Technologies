using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace ServiceTest
{
    internal class ClientTest : IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ClientTest(int clientId, string name, string surname)
        {
            Id = clientId;
            Name = name;
            Surname = surname;
        }
    }
}
