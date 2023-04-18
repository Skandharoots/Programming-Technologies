using System.Collections.ObjectModel;
using Data.API;

namespace Data.Implementation
{

    internal class DataContext : IDataContext
    {
        internal List<IClient> clients = new();
        internal Dictionary<int, IRecord> records = new();
        internal List<IEvent> events = new();
        internal List<IRecordStatus> recordStatuses = new();

    }

}