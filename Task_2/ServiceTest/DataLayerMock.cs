using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace ServiceTest
{
    internal class DataLayerMock : DataLayerAPI
    {

        public List<IClient> Clients = new List<IClient>();
        public List<IEvent> Events = new List<IEvent>();
        public List<IRecord> Records = new List<IRecord>();
        public List<IRecordStatus> RecordStatuses = new List<IRecordStatus>();


        public override void AddClient(string name, string surname)
        {
            Clients.Add(new ClientTest(Clients.Count + 1, name, surname));
        }

        public override void DeleteClient(int id)
        {
            Clients.RemoveAt(id - 1);
        }

        public override void UpdateClientName(int id, string name)
        {
            Clients[id - 1].Name = name;
        }

        public override void UpdateClientSurname(int id, string surname)
        {
            Clients[id - 1].Surname = surname;
        }

        public override IClient GetClient(int id)
        {
            return Clients[id - 1];
        }

        public override IEnumerable<IClient> GetAllClients()
        {
            var result = new List<IClient>();

            foreach (var client in Clients)
            {
                result.Add(client);
            }

            return result;
        }



        public override void AddEvent(int clientId, int recordId, DateTime purchaseDate)
        {
            Events.Add(new EventTest(Events.Count + 1, clientId, recordId, purchaseDate));
        }

        public override void DeleteEvent(int id)
        {
            Events.RemoveAt(id - 1);
        }

        public override void UpdateEventClient(int id, int clientId)
        {
            Events[id - 1].ClientId = clientId;
        }

        public override void UpdateEventRecord(int id, int recordId)
        {
            Events[id - 1].ClientId = recordId;
        }

        public override void UpdateEventPurchaseDate(int id, DateTime purchaseDate)
        {
            Events[id - 1].PurchaseDate = purchaseDate;
        }

        public override IEvent GetEvent(int id)
        {
            return Events[id - 1];
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            var result = new List<IEvent>();

            foreach (var e in Events)
            {
                result.Add(e);
            }

            return result;
        }



        public override void AddRecord(string author, string title)
        {
            Records.Add(new RecordTest(Records.Count + 1, author, title));
        }

        public override void DeleteRecord(int id)
        {
            Records.RemoveAt(id - 1);
        }

        public override void UpdateRecordAuthor(int id, string author)
        {
            Records[id - 1].Author = author;
        }

        public override void UpdateRecordTitle(int id, string title)
        {
            Records[id - 1].Title = title;
        }

        public override IRecord GetRecord(int id)
        {
            return Records[id - 1];
        }

        public override IEnumerable<IRecord> GetAllRecords()
        {
            var result = new List<IRecord>();

            foreach (var e in Records)
            {
                result.Add(e);
            }

            return result;
        }

        public override void AddRecordStatus(int recordId, bool sold)
        {
            RecordStatuses.Add(new RecordStatusTest(RecordStatuses.Count + 1, recordId, sold));
        }

        public override void DeleteRecordStatus(int id)
        {
            RecordStatuses.RemoveAt(id - 1);
        }

        public override void UpdateRecordStatusRecord(int id, int recordId)
        {
            RecordStatuses[id - 1].RecordId = recordId;
        }

        public override void UpdateRecordStatusSold(int id, bool sold)
        {
            RecordStatuses[id - 1].Sold = sold;
        }

        public override IRecordStatus GetRecordStatus(int id)
        {
            return RecordStatuses[id - 1];
        }

        public override IEnumerable<IRecordStatus> GetAllRecordStatuses()
        {
            var result = new List<IRecordStatus>();

            foreach (var e in RecordStatuses)
            {
                result.Add(e);
            }

            return result;
        }

    }
}