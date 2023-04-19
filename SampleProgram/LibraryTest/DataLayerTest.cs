using Data.API;
using Data.Implementation;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System.Collections.ObjectModel;

namespace TestLibrary
{
    public class DataLayerTests
    {

        [Test]
        public void FillRandom() 
        {
            var datarepo = IDataRepository.CreateRandomRepo();
            int clients = datarepo.GetAllClients().Count();
            Assert.IsNotNull(clients);
            int records = datarepo.GetAllRecords().Count();
            Assert.IsNotNull(records);
            int events = datarepo.GetAllEvents().Count();
            Assert.IsNotNull(events);
            int recordStatuses = datarepo.GetAllRecordStatus().Count();
            Assert.IsNotNull(recordStatuses);
        }

       /* [Test]
        public void FillRandomClients()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 30;
            random.FillClients(cont);
            int actual = cont.clients.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillRandomRecords()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 10;
            random.FillRecords(cont);
            int actual = cont.records.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillRandomEvents()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 30;
            random.FillClients(cont);
            random.FillRecords(cont);
            random.FillRecordStatuses(cont);
            random.FillEvents(cont);
            int actual = cont.events.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillRandomRecordStatuses()
        {
            DataContext cont = new DataContext();
            FillRandom random = new FillRandom();
            int expAmount = 10;
            random.FillRecords(cont);
            random.FillRecordStatuses(cont);
            int actual = cont.recordStatuses.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantClients()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.FillClients(cont);
            int expAmount = 20;
            int actual = cont.clients.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantRecords()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.FillRecords(cont);
            int expAmount = 20;
            int actual = cont.records.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantEvents()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.FillClients(cont);
            constant.FillRecords(cont);
            constant.FillEvents(cont);
            int expAmount = 20;
            int actual = cont.events.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void FillConstantRecordStatuses()
        {
            DataContext cont = new DataContext();
            FillConstant constant = new FillConstant();
            constant.FillClients(cont);
            constant.FillRecords(cont);
            constant.FillEvents(cont);
            constant.FillRecordStatuses(cont);
            int expAmount = 20;
            int actual = cont.recordStatuses.Count;
            Assert.AreEqual(actual, expAmount);
        }

        [Test]
        public void RepositoryAddClient()
        {

            repoE.AddClient(c);
            int expected = 1;
            int actual = repoE.DataContext.clients.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteClient()
        {
            int amount = repo.DataContext.clients.Count;
            repo.DeleteClient(repo.GetClient(0));
            int expected = amount - 1;
            int actual = repo.DataContext.clients.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetClient()
        {
            repoE.AddClient(c);
            Assert.AreSame(c, repoE.GetClient(0));
        }

        [Test]
        public void RepositoryGetAllClients()
        {
            List<Client> allClients = (List<Client>)repo.GetAllClients();
            bool allActualClients = repo.DataContext.clients.SequenceEqual(allClients);
            Assert.AreEqual(true, allActualClients);
        }

        [Test]
        public void RepositoryUpdateClient()
        {
            string expectedName = "John";
            string expectedSurname = "Wick";
            repo.UpdateClient(3, "John", "Wick");
            Assert.AreEqual(expectedName, repo.GetClient(3).Name);
            Assert.AreEqual(expectedSurname, repo.GetClient(3).Surname);
        }

        [Test]
        public void RepositoryAddRecord()
        {
            repoE.AddRecord(r);
            int expected = 1;
            Assert.AreEqual(expected, repoE.DataContext.records.Count);
        }

        [Test]
        public void RepositoryDeleteRecord()
        {
            int size = 20;
            repo.DeleteRecord(3);
            int expected = size - 1;
            int actual = repo.DataContext.records.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryGetRecord()
        {
            repoE.AddRecord(r);
            Assert.AreEqual(r, repoE.GetRecord(0));
        }

        [Test]
        public void RepositoryGetAllRecords()
        {
            List<Record> allRecords = (List<Record>)repo.GetAllRecords();
            List<Record> allActualRecords = (List<Record>)repo.DataContext.records.Values.ToList();
            bool actual = allActualRecords.SequenceEqual(allRecords);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecord()
        {
            string expectedAuthor = "Nirvana";
            string expectedTitle = "Nevermind";
            repo.UpdateRecord(5, "Nirvana", "Nevermind");
            Assert.AreEqual(expectedTitle, repo.GetRecord(5).Title);
            Assert.AreEqual(expectedAuthor, repo.GetRecord(5).Author);
        }

        [Test]
        public void RepositoryAddRecordStatus()
        {
            repo.AddRecordStatus(rs);
            Assert.AreEqual(rs, repo.GetRecordStatus(20));
        }

        [Test]
        public void RepositoryDeleteRecordStatus()
        {
            repo.DeleteRecordStatus(repo.GetRecordStatus(0));
            Assert.AreEqual(19, repo.DataContext.recordStatuses.Count);
        }

        [Test]
        public void RepositoryGetRecordStatus()
        {
            repo.AddRecordStatus(rs);
            RecordStatus actual = repo.GetRecordStatus(20);
            Assert.AreEqual(rs, actual);
        }

        [Test]
        public void RepositoryGetAllRecordStatuses()
        {
            List<RecordStatus> allStatuses = (List<RecordStatus>)repo.GetAllRecordStatus();
            bool actual = repo.DataContext.recordStatuses.SequenceEqual(allStatuses);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateRecordStatuses()
        {
            Record expectedRecord = new Record("A", "A");
            DateTime expectedPurchaseDate = DateTime.Today;
            repo.UpdateStatus(0, expectedRecord, expectedPurchaseDate);
            Record actualRec = repo.GetRecordStatus(0).Record;
            DateTime actualDate = repo.GetRecordStatus(0).DateOfPurchase;
            Assert.AreEqual(expectedRecord, actualRec);
            Assert.AreEqual(expectedPurchaseDate, repo.GetRecordStatus(0).DateOfPurchase);
        }

        [Test]
        public void RepositoryAddEvent()
        {
            repo.AddEvent(e);
            int expected = 20 + 1;
            int actual = repo.DataContext.events.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RepositoryDeleteEvent()
        {
            repo.EventDelete(repo.GetEvent(0));
            int actual = repo.DataContext.events.Count;
            Assert.AreEqual(19, actual);
        }

        [Test]
        public void RepositoryGetEvent()
        {
            repo.AddEvent(e);
            Assert.AreEqual(e, repo.GetEvent(20));
        }

        [Test]
        public void RepositoryGetAllEvents()
        {
            ObservableCollection<Event> allEvents = (ObservableCollection<Event>)repo.GetAllEvents();
            bool actual = repo.DataContext.events.SequenceEqual(allEvents);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RepositoryUpdateEvent()
        {
            Client expectedClient = new Client("Emily", "Johnson");
            Record expectedRecord = new Record("Sophia Martinez", "Dreamland Odyssey");
            DateTime expectedRentDate = DateTime.Parse("07-Apr-2023 08:30:00 AM");
            DateTime expectedDueDate = DateTime.Parse("14-Apr-2023 08:30:00 AM");
            repo.UpdateEvent(0, expectedClient, expectedRecord, expectedRentDate, expectedDueDate);
            Client actualClient = repo.GetEvent(0).MusicEnthusiast;
            Record actualRecord = repo.GetEvent(0).Record;
            DateTime actualRentDate = repo.GetEvent(0).PurchaseDate;
            DateTime actualDueDate = repo.GetEvent(0).ReturnDate;
            Assert.AreEqual(expectedClient, actualClient);
            Assert.AreEqual(expectedRecord, actualRecord);
            Assert.AreEqual(expectedRentDate, actualRentDate);
            Assert.AreEqual(expectedDueDate, actualDueDate);
        }
       */
    }
}