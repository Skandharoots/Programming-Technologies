using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data.API;
[assembly: InternalsVisibleTo("LogicTest")]

namespace Logic.Implementation
{
    internal class Client : IClient
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }

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

    internal class RecordStatus : IRecordStatus
    {
        public IRecord record { get; set; }
        public bool available { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public RecordStatus(bool available, IRecord record, DateTime dateOfPurchase)
        {
            this.record = record;
            this.available = available;
            DateOfPurchase = dateOfPurchase;
        }
    }

    internal class Rent : IEvent
    {
        public IClient client { get; set; }

        public IRecordStatus status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Rent(IClient client, IRecordStatus status, DateTime rentalDate, DateTime returnDate = default)
        {
            this.client = client;
            this.status = status;
            PurchaseDate = rentalDate;
            ReturnDate = returnDate;
        }
    }

    internal class Return : IEvent
    {
        public IClient client { get; set; }

        public IRecordStatus status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Return(IClient client, IRecordStatus status, DateTime returnDate = default)
        {
            this.client = client;
            this.status = status;
            ReturnDate = returnDate;
        }
       
    }

    internal class DataContext : IDataContext
    {

        internal List<IClient> clients = new();
        internal Dictionary<int, IRecord> records = new();
        internal List<IEvent> events = new();
        internal List<IRecordStatus> recordStatuses = new();
    }

    internal class DataRepository : IDataRepository
    {
        private DataContext _dataContext;

        public DataRepository(IDataGeneration generate)
        {
            if (generate != null)
            {
                _dataContext = new DataContext();
                generate.Fill(this);
            }
            else { _dataContext = new DataContext(); }
        }

        //Methods for Client class

        public override void AddClient(IClient client)
        {
            _dataContext.clients.Add(client);
        }

        public override void DeleteClient(IClient client)
        {
            _dataContext.clients.Remove(client);
        }

        public override IClient GetClient(int pos)
        {
            return _dataContext.clients[pos];
        }

        public override IEnumerable<IClient> GetAllClients()
        {
            return _dataContext.clients;
        }

        public override void UpdateClient(int pos, string name = "default", string surname = "default")
        {
            if (name != "default")
                _dataContext.clients[pos].Name = name;

            if (surname != "default")
                _dataContext.clients[pos].Surname = surname;
        }

        //Methods for class Record

        public override void AddRecord(IRecord record)
        {
            _dataContext.records.Add(record.Id, record);
        }

        public override void DeleteRecord(int pos)
        {
            _dataContext.records.Remove(pos);
        }

        public override IRecord GetRecord(int pos)
        {
            return _dataContext.records.ElementAt(pos).Value;
        }

        public override IEnumerable<IRecord> GetAllRecords()
        {
            List<IRecord> recordsList = new List<IRecord>();
            recordsList.AddRange(_dataContext.records.Values);
            return recordsList;
        }

        public override void UpdateRecord(int pos, string author = "default", string title = "default")
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

        public override void AddRecordStatus(IRecordStatus status)
        {
            _dataContext.recordStatuses.Add(status);
        }

        public override void DeleteRecordStatus(IRecordStatus status)
        {
            _dataContext.recordStatuses.Remove(status);
        }

        public override IRecordStatus GetRecordStatus(int position)
        {
            return _dataContext.recordStatuses[position];
        }

        public override IEnumerable<IRecordStatus> GetAllRecordStatus()
        {
            List<IRecordStatus> statusList = new List<IRecordStatus>(_dataContext.recordStatuses);
            return statusList;
        }

        // Methods for Event class

        public override void AddEvent(IEvent newEvent)
        {
            _dataContext.events.Add(newEvent);
        }

        public override void EventDelete(IEvent eventDeletion)
        {
            _dataContext.events.Remove(eventDeletion);
        }

        public override IEvent GetEvent(int position)
        {
            return _dataContext.events[position];
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            return _dataContext.events;
        }

        public override void UpdateEvent(int update, IClient client, IRecordStatus status, DateTime purchaseDate = default(DateTime), DateTime returnDate = default(DateTime))
        {
            if (_dataContext.events[update].client != null)
                _dataContext.events[update].client = client;

            if (_dataContext.events[update].status != null)
                _dataContext.events[update].status = status;

            if (purchaseDate != default(DateTime))
                _dataContext.events[update].PurchaseDate = purchaseDate;

            if (returnDate != default(DateTime))
                _dataContext.events[update].ReturnDate = returnDate;
        }
    }
        
}
