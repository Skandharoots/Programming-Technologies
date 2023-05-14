using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataBase;
using Data.Implementation;

namespace Data.API
{
    public abstract class DataLayerAPI
    {
        public abstract void AddClient(string name, string surname);
        public abstract void DeleteClient(int id);
        public abstract void UpdateClientName(int id, string name);
        public abstract void UpdateClientSurname(int id, string surname);
        public abstract IClient GetClient(int id);
        public abstract IEnumerable<IClient> GetAllClients();
        //////////////////////////////////////////
        public abstract void AddRecord(string author, string title);
        public abstract void DeleteRecord(int id);
        public abstract void UpdateRecordAuthor(int id, string author);
        public abstract void UpdateRecordTitle(int id, string title);
        public abstract IRecord GetRecord(int id);
        public abstract IEnumerable<IRecord> GetAllRecords();
        //////////////////////////////////////////
        public abstract void AddRecordStatus(int recordId, bool sold);
        public abstract void DeleteRecordStatus(int id);
        public abstract void UpdateRecordStatusSold(int id, bool sold);
        public abstract void UpdateRecordStatusRecord(int id, int recordId);
        public abstract IRecordStatus GetRecordStatus(int id);
        public abstract IEnumerable<IRecordStatus> GetAllRecordStatuses();
        /// //////////////////////////////////////////
        public abstract void AddEvent(int clientId, int recordId, DateTime purchaseDate);
        public abstract void DeleteEvent(int id);
        public abstract void UpdateEventClient(int id, int clientId);
        public abstract void UpdateEventRecord(int id, int reocrdId);
        public abstract void UpdateEventPurchaseDate(int id, DateTime purchaseDate);
        public abstract IEvent GetEvent(int id);
        public abstract IEnumerable<IEvent> GetAllEvents();

        public static DataLayerAPI CreateLayer()
        {
            return new DataLayerIMP();
        }

    
    }
}
