using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IClientModelData
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}
