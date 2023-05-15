using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace ServiceTest
{
    internal class RecordTest : IRecord
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public RecordTest(int id, string author, string title)
        {
            Id = id;
            Author = author;
            Title = title;
        }
    }
}
