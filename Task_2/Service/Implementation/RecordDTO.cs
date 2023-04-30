using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public RecordDTO(int id, string author, string title)
        {
            Id = id;
            Author = author;
            Title = title;
        }
    }
}
