using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.Implementation
{
    internal class Customers : IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Customers(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
