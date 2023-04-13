using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordStore
{
    public class DataService
    {

        private DataRepository _repository;

        public DataRepository repo
        {
            get { return _repository; }
            set { _repository = value; }
        }

        public DataService(DataRepository newRepository)
        {
            repo = newRepository;
            repo.Generate();
        }

        public Event AddEvent(Client client, RecordStatus status)
        {
            Event newEvent = null;
            int recordsAmount = repo.DataContext.records.Count;
            for (int i = 0; i < recordsAmount; i++)
            {
                if (repo.DataContext.records[i].Equals(status.Record)) 
                {
                    newEvent = new Event(repo.DataContext.records[i], client,  DateTime.Now);
                    repo.AddEvent(newEvent);
                }
            }
            return newEvent;
        }

        public Event FindEvent(Client client, RecordStatus status) 
        {
            Event _event = null;
            Record record = null;

            int recordsAmount = repo.DataContext.records.Count;
            int eventsAmount = repo.DataContext.events.Count;

            for (int i = 0; i < recordsAmount; i++)
            {
                if (repo.DataContext.records.ElementAt(i).Value.Equals(status.Record))
                {
                    record = repo.DataContext.records.ElementAt(i).Value;
                    for (int j = 0; j < eventsAmount; j++)
                    {
                        if (repo.DataContext.events[j].Record.Equals(record) && repo.DataContext.events[j].MusicEnthusiast.Equals(client))
                        {
                            _event = repo.DataContext.events[j];
                        }
                    }
                    break;
                }
            }
            return _event;
        }

        public IEnumerable<Event> EventsBetween(DateTime start, DateTime end)
        {
            ObservableCollection<Event> eventsBetween = new ObservableCollection<Event>();
            int eventsAmount = repo.DataContext.events.Count;
            for (int i = 0; i < eventsAmount; i++) 
            {
                if ((repo.DataContext.events[i].PurchaseDate >= start) && (repo.DataContext.events[i].ReturnDate <= end))
                {
                    eventsBetween.Add(repo.DataContext.events[i]);
                }
            }
            return eventsBetween;
        }

        public Record FindRecord(RecordStatus status)
        {
            Record record = null;
            int recordsAmount = repo.DataContext.records.Count;
            for (int i = 0; i < recordsAmount; i++)
            {
                if (repo.DataContext.records[i].Equals(status.Record))
                {
                    record = repo.DataContext.records[i];
                }
            }
            return record;
        }

        public IEnumerable<Record> ListAllRecords()
        {
            List<Record> records = new List<Record>();
            records.AddRange(repo.DataContext.records.Values);
            return records;
        }

        public IEnumerable<RecordStatus> ListAllStatus()
        {
            IEnumerable<RecordStatus> statuses = repo.GetAllRecordStatus();
            return statuses;
        }

        public IEnumerable<Event> ListAllEvents()
        {
            IEnumerable<Event> events = repo.GetAllEvents();
            return events;
        }

        public IEnumerable<Client> ListAllClients()
        {
            IEnumerable<Client> clients = repo.GetAllClients();
            return clients;
        }

        public IEnumerable<Event> ListAllClientEvents(Client client)
        {
            ObservableCollection<Event> clientEvents = new ObservableCollection<Event>();
            int eventsAmmount = repo.DataContext.events.Count;
            for (int i = 0; i < eventsAmmount; i++)
            {
                if (repo.DataContext.events[i].MusicEnthusiast.Equals(client))
                {
                    clientEvents.Add(repo.DataContext.events[i]);
                }
            }
            return clientEvents;
        }



    }
}
