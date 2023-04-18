using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IRecord
    {
        int Id { get; set; }

        string Title { get; set; }

        string Author { get; set; }
        
    }
}
