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
        
        private IDataRepository repository;



        public DataService(IDataRepository newRepository) {
            repository = newRepository;
        }

        public override IDataRepository GetRepo()
        {
            return repository;
        }

        public override IEvent FindEvent(IRecordStatus status)  {
            IEvent _event = null;
            IRecord record = null;

            int recordsAmount = repository.GetAllRecords().Count();
            int eventsAmount = repository.GetAllEvents().Count();

            for (int i = 0; i < recordsAmount; i++) {
                if (repository.GetRecord(i).Equals(status.record)) {
                    record = repository.GetRecord(i);
                    for (int j = 0; j < eventsAmount; j++) {
                        if (repository.GetEvent(j).status.record.Equals(record))
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
                if (repository.GetRecord(i) == status.record)
                    record = repository.GetRecord(i);
            }
            return record;
        }

        public override IEvent FindClientEvent(IClient myclient) {
            IEvent myevent = null;
            int eventsAmount = repository.GetAllEvents().Count();

            for (int i = 0; i < eventsAmount; i++)
            {
                if (repository.GetEvent(i).client == myclient)
                    myevent = repository.GetEvent(i);
            }
            return myevent;
        }

        public override void RentRecord(IClient client, IRecordStatus status)
        {
            IRecordStatus mystatus = null;
            
            int id = 0;
            for (int i = 0; i < repository.GetAllRecordStatus().Count(); i++)
            {
                if (repository.GetRecordStatus(i) == status)
                {
                    mystatus = repository.GetRecordStatus(i);
                    id = i;
                }
            }
            if (mystatus.available == false)
            {
                throw new InvalidOperationException("Cannot rent an already rented record.");
            }
            else
            {
                IEvent myev = IEvent.CreateEvent(IEvent.Eventkind.rent, client, status);
                repository.AddEvent(myev);
                repository.GetRecordStatus(id).available = false;
            }
        }

        public override void ReturnRecord(IClient client, IRecordStatus status) 
        {
            IRecordStatus mystatus = null;
            int id = 0;
            for (int i = 0; i < repository.GetAllRecordStatus().Count(); i++)
            {
                if (repository.GetRecordStatus(i) == status)
                {
                    mystatus = repository.GetRecordStatus(i);
                    id = i;
                }
            }
            if (mystatus.available == true)
            {
                throw new InvalidOperationException("Cannot return an already returned record.");
            }
            else
            {
                IEvent myev = IEvent.CreateEvent(IEvent.Eventkind.ret, client, status);
                repository.AddEvent(myev);
                repository.GetRecordStatus(id).available = true;
            }
        }
    }
}
