using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data.Implementation;
[assembly: InternalsVisibleTo("LibraryTest")]
[assembly: InternalsVisibleTo("Logic")]

namespace Data.API {
    public abstract class IDataRepository {
        public abstract void AddClient(IClient client);
        public abstract void DeleteClient(IClient client);
        public abstract IClient GetClient(int pos);
        public abstract IEnumerable<IClient> GetAllClients();
        public abstract void UpdateClient(int pos, string name = "default", string surname = "default");
        public abstract void AddRecord(IRecord record);
        public abstract void DeleteRecord(int pos);
        public abstract IRecord GetRecord(int pos);
        public abstract IEnumerable<IRecord> GetAllRecords();

        public abstract void UpdateRecord(int pos, string author = "default", string title = "default");
        public abstract void AddRecordStatus(IRecordStatus status);
        public abstract void DeleteRecordStatus(IRecordStatus status);
        public abstract IRecordStatus GetRecordStatus(int position);
        public abstract IEnumerable<IRecordStatus> GetAllRecordStatus();
        public abstract void AddEvent(IEvent newEvent);
        public abstract void EventDelete(IEvent eventDeletion);
        public abstract IEvent GetEvent(int position);
        public abstract IEnumerable<IEvent> GetAllEvents();
        public abstract void UpdateEvent(int update, int recordId, DateTime purchaseDate = default(DateTime), DateTime returnDate = default(DateTime));

        public static IDataRepository CreateConstantRepo(IDataGeneration? gen = default) {
            return new DataRepository(gen ?? new FillConstant());
        }

        public static IDataRepository CreateRandomRepo(IDataGeneration? gen = default) {
            return new DataRepository(gen ?? new FillRandom());
        }
    }
}
