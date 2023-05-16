using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Data.DataBase;

namespace Data.Implementation
{
    internal class DataLayerIMP : DataLayerAPI
    {
        private DataClasses1DataContext context;

        public DataLayerIMP()
        {
            context = new DataClasses1DataContext();
        }

        private IClient Transform(Client user)
        {
            return new Customers(user.Id, user.Name, user.Surname);
        }

        private IEvent Transform(Event events)
        {
            return new Events(events.Id, events.ClientID, events.RecordId);
        }

        private IRecord Transform(Record product)
        {
            return new Records(product.Id, product.Author, product.Title);
        }

        private IRecordStatus Transform(RecordStatus product)
        {
            return new RecordStatuses(product.Id, product.RecordId, product.Sold);
        }

        public override void AddClient(int id, string name, string surname)
        {
            var client = new Client
            {
                Id = id,
                Name = name,
                Surname = surname
            };

            context.Clients.InsertOnSubmit(client);
            context.SubmitChanges();
        }

        public override void DeleteClient(int id)
        {
            Client client = context.Clients.SingleOrDefault(x => x.Id == id);

            context.Clients.DeleteOnSubmit(client);
            context.SubmitChanges();
        }

        public override void UpdateClientName(int id, string name)
        {
            Client client = context.Clients.SingleOrDefault(x => x.Id == id);
            client.Name = name;
            
            context.SubmitChanges();
        }

        public override void UpdateClientSurname(int id, string surname)
        {
            Client client = context.Clients.SingleOrDefault(x => x.Id == id);
            client.Surname = surname;

            context.SubmitChanges();
        }

        public override IClient GetClient(int id)
        {
            var userDatabase = (from user in context.Clients where user.Id == id select user).SingleOrDefault();
            return userDatabase != null ? Transform(userDatabase) : null;

        }

        public override IEnumerable<IClient> GetAllClients()
        {
            var users = from user in context.Clients select Transform(user);
            return users;
        }

        //////////////////////////////////////////
        public override void AddRecord(int id, string author, string title)
        {
            var record = new Record
            {
                Id = id,
                Author = author,
                Title = title
            };
            context.Records.InsertOnSubmit(record);
            context.SubmitChanges();
        }

        public override void DeleteRecord(int id)
        {
            Record record = context.Records.SingleOrDefault(x => x.Id == id);

            context.Records.DeleteOnSubmit(record);
            context.SubmitChanges();
        }

        public override void UpdateRecordAuthor(int id, string author)
        {
            Record record = context.Records.SingleOrDefault(x => x.Id == id);
            record.Author = author;

            context.SubmitChanges();
        }

        public override void UpdateRecordTitle(int id, string title)
        {
            Record record = context.Records.SingleOrDefault(x => x.Id == id);
            record.Title = title;

            context.SubmitChanges();
        }

        public override IRecord GetRecord(int id)
        {
            var productDatabase = (from product in context.Records where product.Id == id select product).SingleOrDefault();
            return productDatabase != null ? Transform(productDatabase) : null;
        }

        public override IEnumerable<IRecord> GetAllRecords()
        {
            var products = from product in context.Records select Transform(product);
            return products;
        }
        //////////////////////////////////////////
        public override void AddRecordStatus(int id, int recordId, bool sold)
        {
            RecordStatus newStatus = new RecordStatus
            {
                Id = id,
                RecordId = recordId,
                Sold = sold
            };
            context.RecordStatus.InsertOnSubmit(newStatus);
            context.SubmitChanges();
        }

        public override void DeleteRecordStatus(int id)
        {
            RecordStatus myStatus = context.RecordStatus.SingleOrDefault(x => x.Id == id);

            context.RecordStatus.DeleteOnSubmit(myStatus);
            context.SubmitChanges();
        }

        public override void UpdateRecordStatusSold(int id, bool sold)
        {
            RecordStatus thisRecordStatus = context.RecordStatus.SingleOrDefault(x => x.Id == id);
            thisRecordStatus.Sold = sold;

            context.SubmitChanges();
        }

        public override void UpdateRecordStatusRecord(int id, int recordId)
        {
            RecordStatus thisRecordStatus = context.RecordStatus.SingleOrDefault(x => x.Id == id);
            thisRecordStatus.RecordId = recordId;

            context.SubmitChanges();
        }

        public override IRecordStatus GetRecordStatus(int id)
        {
            var productDatabase = (from product in context.RecordStatus where product.Id == id select product).SingleOrDefault();
            return productDatabase != null ? Transform(productDatabase) : null;

        }

        public override IEnumerable<IRecordStatus> GetAllRecordStatuses()
        {
            var products = from product in context.RecordStatus select Transform(product);
            return products;
        }


        /// ///////////////////////////////////////
        public override void AddEvent(int id, int clientId, int recordId, DateTime purchaseDate)
        {
            Event newEvent = new Event
            {
                Id = id,
                ClientID = clientId,
                RecordId = recordId,
                PurchaseDate = purchaseDate
            };
            context.Events.InsertOnSubmit(newEvent);
            context.SubmitChanges();
        }

        public override void DeleteEvent(int id)
        {
            Event myEvent = context.Events.SingleOrDefault(x => x.Id == id);

            context.Events.DeleteOnSubmit(myEvent);
            context.SubmitChanges();
        }

        public override void UpdateEventClient(int id, int clientId)
        {
            Event thisEvent = context.Events.SingleOrDefault(x => x.Id == id);
            thisEvent.ClientID = clientId;

            context.SubmitChanges();
        }

        public override void UpdateEventRecord(int id, int recordId)
        {
            Event myEvent = context.Events.SingleOrDefault(x => x.Id == id);
            myEvent.RecordId = recordId;

            context.SubmitChanges();
        }

        public override void UpdateEventPurchaseDate(int id, DateTime purchaseDate)
        {
            Event myEvent = context.Events.SingleOrDefault(x => x.Id == id);
            myEvent.PurchaseDate = purchaseDate;

            context.SubmitChanges();
        }

        public override IEvent GetEvent(int id)
        {
            var productDatabase = (from product in context.Events where product.Id == id select product).SingleOrDefault();
            return productDatabase != null ? Transform(productDatabase) : null;
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            var products = from product in context.Events select Transform(product);
            return products;
        }
    }
}
