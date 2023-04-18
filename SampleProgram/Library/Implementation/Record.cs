using Data.API;

namespace Data.Implementation
{

    internal class Record : IRecord
    {
        public int Id { get; set; }

        public string Title { get; set; } 
        
        public string Author { get; set; } 
        

        public Record(int id, string title, string author)
        {
            Id = id;
            Author = author;
            Title = title;
        }

    }
}