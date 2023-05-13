using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;

namespace Presentation.Model
{
    internal class ClientModelData : IClientModelData
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }

        internal ClientModelData(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
