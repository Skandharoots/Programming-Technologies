using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IClientModelData
    {
        int Id { get; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}
