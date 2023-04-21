
using Data.API;
using Logic.Implementation;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LibraryTest")]

namespace Logic.API {

    public abstract class IDataService {

        public abstract IDataRepository GetRepo();

        public abstract IEvent AddEvent(IRecordStatus status);

        public abstract IEvent FindEvent(IRecordStatus status);

        public abstract IRecord FindRecord(IRecordStatus status);
        
        public abstract IEnumerable<IEvent> EventsBetween(DateTime start, DateTime end);

        public static IDataService CreateService(IDataRepository? dataRepository = default)
        {
            return new DataService(dataRepository);
        }

    }
}