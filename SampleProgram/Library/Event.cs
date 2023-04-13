namespace RecordStore
{

    public class Event
    {
        private Client _musicEnthusiast;

        private Record _record;

        private DateTime _rentalDate;

        private DateTime _returnDate;
        
        public Client MusicEnthusiast
        {
            get { return _musicEnthusiast; }
            set { _musicEnthusiast = value; }
        }

        public Record Record 
        {
            get { return _record; }
            set { _record = value; }
        }
        
        public DateTime PurchaseDate {
            get { return _rentalDate; }
            set { _rentalDate = value; }
        }

        public DateTime ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        public Event(Record record, Client client, DateTime rentalDate, DateTime returnDate = default(DateTime))
        {
            _record = record;
            _musicEnthusiast = client;
            _rentalDate = rentalDate;
            _returnDate = returnDate;
        }

    }
}