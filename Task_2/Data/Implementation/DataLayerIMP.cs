using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Data.DataBase;

namespace Data.Implementation
{
    internal class DataLayerIMP : DataLayerAPI
    {
        private LinqToSqlDataContext context;
        public DataLayerIMP()
        {
            context = new LinqToSqlDataContext();
        }

        public override void AddClient(string name, string surname)
        {
            var client = new Client
            {
                Id = context.Clients.Count() + 1,
                Name = name,
                Surname = surname
            };

            context.Clients.InsertOnSubmit(client);
            context.SubmitChanges();
        }

        public override void DeleteClient(int id)
        {
            Client client = context.Clients.FirstOrDefault(x => x.Id == id);

            context.Clients.DeleteOnSubmit(client);
            context.SubmitChanges();
        }

        public override void UpdateClientName(int id, string name)
        {
            Client client = context.Clients.FirstOrDefault(x => x.Id == id);
            client.Name = name;

            context.SubmitChanges();
        }

        public override void UpdateClientSurname(int id, string surname)
        {
            Client client = context.Clients.FirstOrDefault(x => x.Id == id);
            client.Name = surname;

            context.SubmitChanges();
        }

        public override IClient GetClient(int id)
        {
            return (IClient)context.Clients.FirstOrDefault(x => x.Id == id);
        }

        public override IEnumerable<IClient> GetAllClients()
        {
            var clients = from x in context.Clients
                          select (IClient)x;

            return clients;
        }

        //////////////////////////////////////////
        public override void AddRecord(string author, string title)
        {
            var record = new Record
            {
                Id = context.Clients.Count() + 1,
                Author = author,
                Title = title
            };
            context.Records.InsertOnSubmit(record);
            context.SubmitChanges();
        }

        public override void DeleteRecord(int id)
        {
            Record record = context.Records.FirstOrDefault(x => x.Id == id);

            context.Records.DeleteOnSubmit(record);
            context.SubmitChanges();
        }

        public override void UpdateRecordAuthor(int id, string author)
        {
            Record record = context.Records.FirstOrDefault(x => x.Id == id);
            record.Author = author;

            context.SubmitChanges();
        }

        public override void UpdateRecordTitle(int id, string title)
        {
            Record record = context.Records.FirstOrDefault(x => x.Id == id);
            record.Title = title;

            context.SubmitChanges();
        }

        public override IRecord GetRecord(int id)
        {
            return (IRecord)context.Records.FirstOrDefault(x => x.Id == id);
        }

        public override IEnumerable<IRecord> GetAllRecords()
        {
            var records = from x in context.Records
                           select (IRecord)x;

            return records;
        }
        //////////////////////////////////////////
        public override void AddRecordStatus(int recordId, bool sold)
        {
            RecordStatus newStatus = new RecordStatus
            {
                Id = context.RecordStatuses.Count() + 1,
                RecordId = recordId,
                Sold = sold
            };
            context.RecordStatuses.InsertOnSubmit(newStatus);
            context.SubmitChanges();
        }

        public override void DeleteRecordStatus(int id)
        {
            RecordStatus myStatus = context.RecordStatuses.FirstOrDefault(x => x.Id == id);

            context.RecordStatuses.DeleteOnSubmit(myStatus);
            context.SubmitChanges();
        }

        public override void UpdateRecordStatusSold(int id, bool sold)
        {
            RecordStatus thisRecordStatus = context.RecordStatuses.FirstOrDefault(x => x.Id == id);
            thisRecordStatus.Sold = sold;

            context.SubmitChanges();
        }

        public override void UpdateRecordStatusRecord(int id, int recordId)
        {
            RecordStatus thisRecordStatus = context.RecordStatuses.FirstOrDefault(x => x.Id == id);
            thisRecordStatus.RecordId = recordId;

            context.SubmitChanges();
        }

        public override IRecordStatus GetRecordStatus(int id)
        {
            return (IRecordStatus)context.RecordStatuses.FirstOrDefault(x => x.Id == id);

        }

        public override IEnumerable<IRecordStatus> GetAllRecordStatuses()
        {
            var recordStatuses = from x in context.RecordStatuses
                          select (IRecordStatus)x;

            return recordStatuses;
        }


        /// ///////////////////////////////////////
        public override void AddEvent(int clientId, int recordId, DateTime purchaseDate)
        {
            Event newEvent = new Event
            {
                Id = context.Clients.Count() + 1,
                ClientId = clientId,
                RecordId = recordId,
                PurchaseDate = purchaseDate
            };
            context.Events.InsertOnSubmit(newEvent);
            context.SubmitChanges();
        }

        public override void DeleteEvent(int id)
        {
            Event myEvent = context.Events.FirstOrDefault(x => x.Id == id);

            context.Events.DeleteOnSubmit(myEvent);
            context.SubmitChanges();
        }

        public override void UpdateEventClient(int id, int clientId)
        {
            Event thisEvent = context.Events.FirstOrDefault(x => x.Id == id);
            thisEvent.ClientId = clientId;

            context.SubmitChanges();
        }

        public override void UpdateEventRecord(int id, int recordId)
        {
            Event myEvent = context.Events.FirstOrDefault(x => x.Id == id);
            myEvent.RecordId = recordId;

            context.SubmitChanges();
        }

        public override void UpdateEventPurchaseDate(int id, DateTime purchaseDate)
        {
            Event myEvent = context.Events.FirstOrDefault(x => x.Id == id);
            myEvent.PurchaseDate = purchaseDate;

            context.SubmitChanges();
        }

        public override IEvent GetEvent(int id)
        {
            return (IEvent)context.Events.FirstOrDefault(x => x.Id == id);
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            var events = from x in context.Events
                         select (IEvent)x;

            return events;
        }
    }
}
