namespace RecordStore
{

    public class Record
    {
        private int _id;

        static int _nextId = 0;

        private string _title;

        private string _author;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public Record(string title, string author)
        {
            _id = Interlocked.Increment(ref _nextId);
            _author = author;
            _title = title;
        }

        public override string ToString()
        {
            return "RecordStoreLibrary [Id: " + _id + ", Title: " + _title + ", Author: " + _author + "]";
        }
        
    }
}