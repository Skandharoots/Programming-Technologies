using Data.API;
using Data.Implementation;
using Data;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System.Collections.ObjectModel;

namespace TestLibrary {

    public class DataLayerTests {

        

        [Test]
        public void RepositoryAddClient() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("A", "B");
            datarepo.AddClient(c);
            int expected = 1;
            int actual = datarepo.GetAllClients().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteClient() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("A", "B");
            datarepo.AddClient(c);
            int amount = datarepo.GetAllClients().Count();
            datarepo.DeleteClient(datarepo.GetClient(0));
            int expected = amount - 1;
            int actual = datarepo.GetAllClients().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetClient() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("A", "B");
            datarepo.AddClient(c);
            Assert.AreSame(c, datarepo.GetClient(0));
        }

        [Test]
        public void RepositoryGetAllClients() {
            var datarepo = IDataRepository.CreateRepo();
            List<IClient> allClients = (List<IClient>)datarepo.GetAllClients();
            bool allActualClients = datarepo.GetAllClients().SequenceEqual(allClients);
            Assert.AreEqual(true, allActualClients);
        }

        [Test]
        public void RepositoryUpdateClient() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("A", "B");
            datarepo.AddClient(c);
            string expectedName = "John";
            string expectedSurname = "Wick";
            datarepo.UpdateClient(0, "John", "Wick");
            Assert.AreEqual(expectedName, datarepo.GetClient(0).Name);
            Assert.AreEqual(expectedSurname, datarepo.GetClient(0).Surname);
        }

        [Test]
        public void RepositoryAddRecord() {
            var datarepo = IDataRepository.CreateRepo();
            IRecord r = new Record(21, "A", "G");
            datarepo.AddRecord(r);
            int expected = 1;
            Assert.AreEqual(expected, datarepo.GetAllRecords().Count());
        }

        [Test]
        public void RepositoryDeleteRecord() {
            var datarepo = IDataRepository.CreateRepo();
            int size = 1;
            datarepo.DeleteRecord(0);
            int expected = size - 1;
            int actual = datarepo.GetAllRecords().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetRecord() {
            var datarepo = IDataRepository.CreateRepo();
            IRecord r = new Record(21, "A", "G");
            datarepo.AddRecord(r);
            Assert.AreEqual(r, datarepo.GetRecord(0));
        }

        [Test]
        public void RepositoryGetAllRecords() {
            var datarepo = IDataRepository.CreateRepo();
            List<IRecord> allRecords = (List<IRecord>)datarepo.GetAllRecords();
            bool actual = allRecords.SequenceEqual(allRecords);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecord() {
            var datarepo = IDataRepository.CreateRepo();
            IRecord rec = new Record(0, "Some", "Thing");
            datarepo.AddRecord(rec);
            string expectedAuthor = "Nirvana";
            string expectedTitle = "Nevermind";
            datarepo.UpdateRecord(0, "Nirvana", "Nevermind");
            Assert.AreEqual(expectedTitle, datarepo.GetRecord(0).Title);
            Assert.AreEqual(expectedAuthor, datarepo.GetRecord(0).Author);
        }

        [Test]
        public void RepositoryAddRecordStatus() {
            var datarepo = IDataRepository.CreateRepo();
            IRecord r = new Record(0, "Nirvana", "Nevermind");
            datarepo.AddRecord(r);
            IRecordStatus rs = new RecordStatus(true, datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(rs);
            Assert.AreEqual(rs, datarepo.GetRecordStatus(0));
        }

        [Test]
        public void RepositoryDeleteRecordStatus() {
            var datarepo = IDataRepository.CreateRepo();
            IRecord r = new Record(0, "Nirvana", "Nevermind");
            datarepo.AddRecord(r);
            IRecordStatus rs = new RecordStatus(true, datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(rs);
            datarepo.DeleteRecordStatus(datarepo.GetRecordStatus(0));
            Assert.AreEqual(0, datarepo.GetAllRecordStatus().Count());
        }

        [Test]
        public void RepositoryGetRecordStatus() {
            var datarepo = IDataRepository.CreateRepo();
            IRecord r = new Record(0, "Nirvana", "Nevermind");
            datarepo.AddRecord(r);
            IRecordStatus rs = new RecordStatus(true, datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(rs);
            IRecordStatus actual = datarepo.GetRecordStatus(0);
            Assert.AreEqual(rs, actual);
        }

        [Test]
        public void RepositoryGetAllRecordStatuses() {
            var datarepo = IDataRepository.CreateRepo();
            List<IRecordStatus> allStatuses = (List<IRecordStatus>)datarepo.GetAllRecordStatus();
            bool actual = datarepo.GetAllRecordStatus().SequenceEqual(allStatuses);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryAddEvent() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("Marek", "Kopania");
            datarepo.AddClient(c);
            IRecord r = new Record(0, "Nirvana", "Nevermind");
            datarepo.AddRecord(r);
            IRecordStatus s = new RecordStatus(true, datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(s);
            IEvent e = new Data.Implementation.Rent(datarepo.GetClient(0), datarepo.GetRecordStatus(0), DateTime.Now, DateTime.Now.AddHours(14));
            datarepo.AddEvent(e);
            int expected = 1;
            int actual = datarepo.GetAllEvents().Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteEvent() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("Marek", "Kopania");
            datarepo.AddClient(c);
            IRecord r = new Record(0, "Nirvana", "Nevermind");
            datarepo.AddRecord(r);
            IRecordStatus s = new RecordStatus(true, datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(s);
            IEvent e = new Data.Implementation.Rent(datarepo.GetClient(0), datarepo.GetRecordStatus(0), DateTime.Now, DateTime.Now.AddHours(14));
            datarepo.AddEvent(e);
            datarepo.EventDelete(datarepo.GetEvent(0));
            int actual = datarepo.GetAllEvents().Count();
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void RepositoryGetEvent() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("Marek", "Kopania");
            datarepo.AddClient(c);
            IRecord r = new Record(0, "Nirvana", "Nevermind");
            datarepo.AddRecord(r);
            IRecordStatus s = new RecordStatus(true, datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(s);
            IEvent e = new Data.Implementation.Rent(datarepo.GetClient(0), datarepo.GetRecordStatus(0), DateTime.Now, DateTime.Now.AddHours(14));
            datarepo.AddEvent(e);
            Assert.AreEqual(e, datarepo.GetEvent(0));
        }

        [Test]
        public void RepositoryGetAllEvents() {
            var datarepo = IDataRepository.CreateRepo();
            List<IEvent> allEvents = (List<IEvent>)datarepo.GetAllEvents();
            bool actual = datarepo.GetAllEvents().SequenceEqual(allEvents);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateEvent() {
            var datarepo = IDataRepository.CreateRepo();
            IClient c = new Client("Marek", "Kopania");
            datarepo.AddClient(c);
            IRecord r = new Record(0, "Nirvana", "Nevermind");
            datarepo.AddRecord(r);
            IRecordStatus s = new RecordStatus(true, datarepo.GetRecord(0), DateTime.Now);
            datarepo.AddRecordStatus(s);
            IEvent e = new Data.Implementation.Rent(datarepo.GetClient(0), datarepo.GetRecordStatus(0), DateTime.Now, DateTime.Now.AddHours(14));
            datarepo.AddEvent(e);
            DateTime expectedRentDate = DateTime.Parse("07-Apr-2023 08:30:00 AM");
            DateTime expectedDueDate = DateTime.Parse("14-Apr-2023 08:30:00 AM");
            datarepo.UpdateEvent(0, datarepo.GetClient(0), datarepo.GetRecordStatus(0), expectedRentDate, expectedDueDate);
            IClient actualClient = datarepo.GetEvent(0).client;
            IRecordStatus actualStatus = datarepo.GetEvent(0).status;
            DateTime actualRentDate = datarepo.GetEvent(0).PurchaseDate;
            DateTime actualDueDate = datarepo.GetEvent(0).ReturnDate;
            Assert.AreEqual(datarepo.GetClient(0), actualClient);
            Assert.AreEqual(datarepo.GetRecordStatus(0), actualStatus);
            Assert.AreEqual(expectedRentDate, actualRentDate);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }
    }
}