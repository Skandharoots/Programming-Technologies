using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.Implementation
{
    internal class Records : IRecord
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
       

        public Records(int productId, string author, string title)
        {
            Id = productId;
            Author = author;
            Title = title;
            
        }
    }
}
