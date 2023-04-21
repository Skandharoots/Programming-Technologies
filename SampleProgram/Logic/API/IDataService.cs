
using Data.API;

namespace Logic.API {

    public abstract class IDataService {
        
        public IDataRepository repository { get; set; }

        public abstract IEvent AddEvent(IRecordStatus status);

        public abstract IEvent FindEvent(IRecordStatus status);

        public abstract IRecord FindRecord(IRecordStatus status);
        
        public abstract IEnumerable<IEvent> EventsBetween(DateTime start, DateTime end);
        
    }
}