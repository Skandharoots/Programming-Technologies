using System.Collections.ObjectModel;

namespace RecordStore
{

    public class DataContext
    {
        public List<Client> clients = new List<Client>();
        public Dictionary<int, Record> records = new Dictionary<int, Record>();
        public ObservableCollection<Event> events = new ObservableCollection<Event>();
        public List<RecordStatus> recordStatuses = new List<RecordStatus>();
        
        public DataContext() {}
        
    }
    
}