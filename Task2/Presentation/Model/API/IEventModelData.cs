using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IEventModelData
    {
        int Id { get; set; }
        int ClientId { get; set; }
        int StatusId { get; set; }
        DateTime PurchaseDate { get; set; }
    }
}
