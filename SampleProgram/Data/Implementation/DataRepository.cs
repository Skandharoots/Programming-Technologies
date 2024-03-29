﻿using Data.API;

namespace Data.Implementation {

    internal class DataRepository : IDataRepository {

        private DataContext _dataContext;

        public DataRepository(IDataGeneration generate) {
            if(generate != null)
            {
                _dataContext = new DataContext();
                generate.Fill(this);
            }
            else { _dataContext = new DataContext(); }
            
        }
        
        //Methods for Client class
        
        public override void AddClient(IClient client) {
            _dataContext.clients.Add(client);
        }
        
        public override void DeleteClient(IClient client) {
            _dataContext.clients.Remove(client);
        }

        public override IClient GetClient(int pos) {
            return _dataContext.clients[pos];
        }

        public override IEnumerable<IClient> GetAllClients() {
            return _dataContext.clients;
        }

        public override void UpdateClient(int pos, string name = "default", string surname = "default") {
            if (name != "default")
                _dataContext.clients[pos].Name = name;

            if (surname != "default")
                _dataContext.clients[pos].Surname = surname;
        }

        //Methods for class Record
        
        public override void AddRecord(IRecord record) {
            _dataContext.records.Add(record.Id, record);
        }
        
        public override void DeleteRecord(int pos) {
            _dataContext.records.Remove(pos);
        }

        public override IRecord GetRecord(int pos) {
            return _dataContext.records.ElementAt(pos).Value;
        }

        public override IEnumerable<IRecord> GetAllRecords() {
            List<IRecord> recordsList = new List<IRecord>();
            recordsList.AddRange(_dataContext.records.Values);
            return recordsList;
        }

        public override void UpdateRecord(int pos, string author = "default", string title = "default") {
            if (author != "default") {
                _dataContext.records[pos].Author = author;
            }

            if (title != "default") {
                _dataContext.records[pos].Title = title;
            }
        }
        
        //Methods for RecordStatus class
        
        public override void AddRecordStatus(IRecordStatus status) {
            _dataContext.recordStatuses.Add(status);
        }
        
        public override void DeleteRecordStatus(IRecordStatus status) {
            _dataContext.recordStatuses.Remove(status);
        }
        
        public override IRecordStatus GetRecordStatus(int position) {
            return _dataContext.recordStatuses[position];
        }
        
        public override IEnumerable<IRecordStatus> GetAllRecordStatus() {
            List<IRecordStatus> statusList = new List<IRecordStatus>(_dataContext.recordStatuses);
            return statusList;
        }
        
        // Methods for Event class
        
        public override void AddEvent(IEvent newEvent) {
            _dataContext.events.Add(newEvent);
        }
        
        public override void EventDelete(IEvent eventDeletion) {
            _dataContext.events.Remove(eventDeletion);
        }
        
        public override IEvent GetEvent(int position) {
            return _dataContext.events[position];
        }
        
        public override IEnumerable<IEvent> GetAllEvents() {
            return _dataContext.events;
        }
        
        public override void UpdateEvent(int update, IClient client, IRecordStatus status, DateTime purchaseDate = default(DateTime), DateTime returnDate = default(DateTime)) {
            if (_dataContext.events[update].client != null)
                _dataContext.events[update].client = client;

            if (_dataContext.events[update].status != null)
                _dataContext.events[update].status = status;

            if (purchaseDate != default(DateTime))
                _dataContext.events[update].PurchaseDate = purchaseDate;

            if (returnDate != default(DateTime))
                _dataContext.events[update].ReturnDate = returnDate;
        }
    }
}