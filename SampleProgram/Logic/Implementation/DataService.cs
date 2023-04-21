using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.API;
using Data.Implementation;
using Logic.API;

namespace Logic.Implementation {
    
    internal class DataService : IDataService {
        
        public IDataRepository repository;

        public DataService(IDataRepository newRepository) {
            repository = newRepository;
        }

        public IEvent AddEvent(IClient client, IRecordStatus status) {
            IEvent newEvent = null;
            int recordsAmount = repository.GetAllRecords().Count();
            for (int i = 0; i < recordsAmount; i++) {
                if (repository.GetRecord(i).Id.Equals(status.RecordId))  {
                    newEvent = new Event(repository.GetRecord(i).Id, DateTime.Now);
                    repository.AddEvent(newEvent);
                }
            }
            return newEvent;
        }

        public IEvent FindEvent(IRecordStatus status)  {
            IEvent _event = null;
            IRecord record = null;

            int recordsAmount = repository.GetAllRecords().Count();
            int eventsAmount = repository.GetAllEvents().Count();

            for (int i = 0; i < recordsAmount; i++) {
                if (repository.GetRecord(i).Id.Equals(status.RecordId)) {
                    record = repository.GetRecord(i);
                    for (int j = 0; j < eventsAmount; j++) {
                        if (repository.GetEvent(j).RecordId.Equals(record.Id))
                            _event = repository.GetEvent(j);
                    }
                    break;
                }
            }
            return _event;
        }

        public IEnumerable<IEvent> EventsBetween(DateTime start, DateTime end) {
            List<IEvent> eventsBetween = new List<IEvent>();
            int eventsAmount = repository.GetAllEvents().Count();
            for (int i = 0; i < eventsAmount; i++)  {
                if ((repository.GetEvent(i).PurchaseDate >= start)
                 && (repository.GetEvent(i).ReturnDate <= end))
                    eventsBetween.Add(repository.GetEvent(i));
            }
            return eventsBetween;
        }

        public Record FindRecord(RecordStatus status) {
            Record record = null;
            int recordsAmount = repo.DataContext.records.Count;
            for (int i = 0; i < recordsAmount; i++) {
                if (repo.DataContext.records[i].Equals(status.Record))
                    record = repo.DataContext.records[i];
            }
            return record;
        }

        public IEnumerable<Record> ListAllRecords() {
            List<Record> records = new List<Record>();
            records.AddRange(repo.DataContext.records.Values);
            return records;
        }

        public IEnumerable<RecordStatus> ListAllStatus() {
            IEnumerable<RecordStatus> statuses = repo.GetAllRecordStatus();
            return statuses;
        }

        public IEnumerable<Event> ListAllEvents() {
            IEnumerable<Event> events = repo.GetAllEvents();
            return events;
        }

        public IEnumerable<Client> ListAllClients() {
            IEnumerable<Client> clients = repo.GetAllClients();
            return clients;
        }

        public IEnumerable<Event> ListAllClientEvents(Client client) {
            ObservableCollection<Event> clientEvents = new ObservableCollection<Event>();
            int eventsAmmount = repo.DataContext.events.Count;
            for (int i = 0; i < eventsAmmount; i++) {
                if (repo.DataContext.events[i].MusicEnthusiast.Equals(client))
                    clientEvents.Add(repo.DataContext.events[i]);
            }
            return clientEvents;
        }
        */
    }
}
