using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Implementation;

namespace Service.API
{
    public interface IRecordDTO
    {
        int Id { get; set; }
        string Author { get; set; }
        string Title { get; set; }
    }
}
