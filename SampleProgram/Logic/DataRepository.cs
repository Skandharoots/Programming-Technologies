namespace RecordStore
{

    public class DataRepository
    {

        private DataContext _dataContext;
        private IDataGeneration _dataGeneration;
        
        public DataContext DataContext
        {
            get { return _dataContext; }
            set { _dataContext = value; }
        }

        public DataRepository(IDataGeneration generate)
        {
            _dataContext = new DataContext();
            _dataGeneration = generate;
        }

        public void Generate()
        {
            _dataGeneration.Fill(_dataContext);
        }
        
        //Methods for Client class
        
        public void AddClient(Client client)
        {
            _dataContext.clients.Add(client);
        }
        
        public void DeleteClient(Client client)
        {
            _dataContext.clients.Remove(client);
        }

        public Client GetClient(int pos)
        {
            return _dataContext.clients[pos];
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _dataContext.clients;
        }

        public void UpdateClient(int pos, string name = "default", string surname = "default")
        {
            if (name != "default")
            {
                _dataContext.clients[pos].Name = name;
            }

            if (surname != "default")
            {
                _dataContext.clients[pos].Surname = surname;
            }
        }

        //Methods for class Record
        
        public void AddRecord(Record record)
        {
            _dataContext.records.Add(record.Id, record);
        }
        
        public void DeleteRecord(int pos)
        {
            _dataContext.records.Remove(pos);
        }

        public Record GetRecord(int pos)
        {
            return _dataContext.records.ElementAt(pos).Value;
        }

        public IEnumerable<Record> GetAllRecords()
        {
            List<Record> recordsList = new List<Record>();
            recordsList.AddRange(_dataContext.records.Values);
            return recordsList;
        }

        public void UpdateRecord(int pos, string author = "default", string title = "default")
        {
            if (author != "default")
            {
                _dataContext.records[pos].Author = author;
            }

            if (title != "default")
            {
                _dataContext.records[pos].Title = title;
            }
        }
        
        //Methods for RecordStatus class
        
        public void AddRecordStatus(RecordStatus status) {
            _dataContext.recordStatuses.Add(status);
        }
        
        public void DeleteRecordStatus(RecordStatus status) {
            _dataContext.recordStatuses.Remove(status);
        }
        
        public RecordStatus GetRecordStatus(int position) {
            return _dataContext.recordStatuses[position];
        }
        
        public IEnumerable<RecordStatus> GetAllRecordStatus() {
            List<RecordStatus> statusList = new List<RecordStatus>(_dataContext.recordStatuses);
            return statusList;
        }
        
        public void UpdateStatus(int position, Record record = null, DateTime purchaseDate = default(DateTime))
        {
            if (record != null) {
                _dataContext.recordStatuses[position].Record = record;
            }
            if (purchaseDate != default(DateTime)) {
                _dataContext.recordStatuses[position].DateOfPurchase = purchaseDate;
            }
        }
        
        // Methods for Event class
        
        public void AddEvent(Event newEvent) {
            _dataContext.events.Add(newEvent);
        }
        
        public void EventDelete(Event eventDeletion) {
            _dataContext.events.Remove(eventDeletion);
        }
        
        public Event GetEvent(int position) {
            return _dataContext.events[position];
        }
        
        public IEnumerable<Event> GetAllEvents() {
            return _dataContext.events;
        }
        
        public void UpdateEvent(int update, Client client = null, Record record = null, DateTime purchaseDate = default(DateTime), DateTime returnDate = default(DateTime)) {
            if (client != null) {
                _dataContext.events[update].MusicEnthusiast = client;
            }
            if (record != null) {
                _dataContext.events[update].Record = record;
            }
            if (purchaseDate != default(DateTime)) {
                _dataContext.events[update].PurchaseDate = purchaseDate;
            }
            if (returnDate != default(DateTime)) {
                _dataContext.events[update].ReturnDate = returnDate;
            }
        }
        

    }
    
}