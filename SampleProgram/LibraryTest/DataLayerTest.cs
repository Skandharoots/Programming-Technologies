using Data.API;
using Data.Implementation;
using Data;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System.Collections.ObjectModel;

namespace TestLibrary {

    public class DataLayerTests {

        [Test]
        public void FillRandom()  {
            var datarepo = IDataRepository.CreateRandomRepo(new FillRandom());
            int clients = datarepo.GetAllClients().Count();
            Assert.IsNotNull(clients);
            int records = datarepo.GetAllRecords().Count();
            Assert.IsNotNull(records);
            int events = datarepo.GetAllEvents().Count();
            Assert.IsNotNull(events);
            int recordStatuses = datarepo.GetAllRecordStatus().Count();
            Assert.IsNotNull(recordStatuses);
        }

        [Test]
        public void FillConstant() {
            var datarepo = IDataRepository.CreateConstantRepo(new FillConstant());
            int clients = datarepo.GetAllClients().Count();
            Assert.IsNotNull(clients);
            int records = datarepo.GetAllRecords().Count();
            Assert.IsNotNull(records);
            int events = datarepo.GetAllEvents().Count();
            Assert.IsNotNull(events);
            int recordStatuses = datarepo.GetAllRecordStatus().Count();
            Assert.IsNotNull(recordStatuses);
        }

        [Test]
        public void RepositoryAddClient() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IClient c = new Client("A", "B");
            datarepo.AddClient(c);
            int expected = 21;
            int actual = datarepo.GetAllClients().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteClient() {
            var datarepo = IDataRepository.CreateConstantRepo();
            int amount = datarepo.GetAllClients().Count();
            datarepo.DeleteClient(datarepo.GetClient(0));
            int expected = amount - 1;
            int actual = datarepo.GetAllClients().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetClient() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IClient c = new Client("A", "B");
            datarepo.AddClient(c);
            Assert.AreSame(c, datarepo.GetClient(20));
        }

        [Test]
        public void RepositoryGetAllClients() {
            var datarepo = IDataRepository.CreateConstantRepo();
            List<IClient> allClients = (List<IClient>)datarepo.GetAllClients();
            bool allActualClients = datarepo.GetAllClients().SequenceEqual(allClients);
            Assert.AreEqual(true, allActualClients);
        }

        [Test]
        public void RepositoryUpdateClient() {
            var datarepo = IDataRepository.CreateConstantRepo();
            string expectedName = "John";
            string expectedSurname = "Wick";
            datarepo.UpdateClient(3, "John", "Wick");
            Assert.AreEqual(expectedName, datarepo.GetClient(3).Name);
            Assert.AreEqual(expectedSurname, datarepo.GetClient(3).Surname);
        }

        [Test]
        public void RepositoryAddRecord() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IRecord r = new Record(21, "A", "G");
            datarepo.AddRecord(r);
            int expected = 21;
            Assert.AreEqual(expected, datarepo.GetAllRecords().Count());
        }

        [Test]
        public void RepositoryDeleteRecord() {
            var datarepo = IDataRepository.CreateConstantRepo();
            int size = 20;
            datarepo.DeleteRecord(3);
            int expected = size - 1;
            int actual = datarepo.GetAllRecords().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetRecord() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IRecord r = new Record(21, "A", "G");
            datarepo.AddRecord(r);
            Assert.AreEqual(r, datarepo.GetRecord(20));
        }

        [Test]
        public void RepositoryGetAllRecords() {
            var datarepo = IDataRepository.CreateConstantRepo();
            List<IRecord> allRecords = (List<IRecord>)datarepo.GetAllRecords();
            bool actual = allRecords.SequenceEqual(allRecords);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecord() {
            var datarepo = IDataRepository.CreateConstantRepo();
            string expectedAuthor = "Nirvana";
            string expectedTitle = "Nevermind";
            datarepo.UpdateRecord(5, "Nirvana", "Nevermind");
            Assert.AreEqual(expectedTitle, datarepo.GetRecord(5).Title);
            Assert.AreEqual(expectedAuthor, datarepo.GetRecord(5).Author);
        }

        [Test]
        public void RepositoryAddRecordStatus() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IRecordStatus rs = new RecordStatus(datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(rs);
            Assert.AreEqual(rs, datarepo.GetRecordStatus(20));
        }

        [Test]
        public void RepositoryDeleteRecordStatus() {
            var datarepo = IDataRepository.CreateConstantRepo();
            datarepo.DeleteRecordStatus(datarepo.GetRecordStatus(0));
            Assert.AreEqual(19, datarepo.GetAllRecordStatus().Count());
        }

        [Test]
        public void RepositoryGetRecordStatus() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IRecordStatus rs = new RecordStatus(datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(rs);
            IRecordStatus actual = datarepo.GetRecordStatus(20);
            Assert.AreEqual(rs, actual);
        }

        [Test]
        public void RepositoryGetAllRecordStatuses() {
            var datarepo = IDataRepository.CreateConstantRepo();
            List<IRecordStatus> allStatuses = (List<IRecordStatus>)datarepo.GetAllRecordStatus();
            bool actual = datarepo.GetAllRecordStatus().SequenceEqual(allStatuses);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryAddEvent() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IEvent e = new Data.Implementation.Event(0, DateTime.Now, DateTime.Now.AddHours(14));
            datarepo.AddEvent(e);
            int expected = 20 + 1;
            int actual = datarepo.GetAllEvents().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteEvent() {
            var datarepo = IDataRepository.CreateConstantRepo();
            datarepo.EventDelete(datarepo.GetEvent(0));
            int actual = datarepo.GetAllEvents().Count();
            Assert.AreEqual(19, actual);
        }

        [Test]
        public void RepositoryGetEvent() {
            var datarepo = IDataRepository.CreateConstantRepo();
            IEvent e = new Data.Implementation.Event(0, DateTime.Now, DateTime.Now.AddHours(14));
            datarepo.AddEvent(e);
            Assert.AreEqual(e, datarepo.GetEvent(20));
        }

        [Test]
        public void RepositoryGetAllEvents() {
            var datarepo = IDataRepository.CreateConstantRepo();
            List<IEvent> allEvents = (List<IEvent>)datarepo.GetAllEvents();
            bool actual = datarepo.GetAllEvents().SequenceEqual(allEvents);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateEvent() {
            var datarepo = IDataRepository.CreateConstantRepo();
            DateTime expectedRentDate = DateTime.Parse("07-Apr-2023 08:30:00 AM");
            DateTime expectedDueDate = DateTime.Parse("14-Apr-2023 08:30:00 AM");
            datarepo.UpdateEvent(0, 0, expectedRentDate, expectedDueDate);
            int actualRecord = datarepo.GetEvent(0).RecordId;
            DateTime actualRentDate = datarepo.GetEvent(0).PurchaseDate;
            DateTime actualDueDate = datarepo.GetEvent(0).ReturnDate;
            Assert.AreEqual(0, actualRecord);
            Assert.AreEqual(expectedRentDate, actualRentDate);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }
    }
}