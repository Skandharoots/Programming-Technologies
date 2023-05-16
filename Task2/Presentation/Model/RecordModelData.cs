using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    internal class RecordModelData : IRecordModelData
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public RecordModelData(int id, string author, string title)
        {
            Id = id;
            Author = author;
            Title = title;
        }
    }
}
