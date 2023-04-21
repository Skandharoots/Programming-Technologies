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

        public override IEvent AddEvent(IRecordStatus status) {
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

        public override IEvent FindEvent(IRecordStatus status)  {
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

        public override IEnumerable<IEvent> EventsBetween(DateTime start, DateTime end) {
            List<IEvent> eventsBetween = new List<IEvent>();
            int eventsAmount = repository.GetAllEvents().Count();
            for (int i = 0; i < eventsAmount; i++)  {
                if ((repository.GetEvent(i).PurchaseDate >= start)
                 && (repository.GetEvent(i).ReturnDate <= end))
                    eventsBetween.Add(repository.GetEvent(i));
            }
            return eventsBetween;
        }

        public override IRecord FindRecord(IRecordStatus status) {
            IRecord record = null;
            int recordsAmount = repository.GetAllRecords().Count();
            for (int i = 0; i < recordsAmount; i++) {
                if (repository.GetRecord(i).Id == status.RecordId)
                    record = repository.GetRecord(i);
            }
            return record;
        }
    }
}
