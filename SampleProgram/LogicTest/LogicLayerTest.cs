
using Logic.API;
using Logic.Implementation;
using NSubstitute;

namespace TestLibrary
{

    public class LogicLayerTest
    {


        private Client c;
        private Record r;
        private RecordStatus rs;
        private Rent e;


        public LogicLayerTest()
        {
            c = new Client("Mateusz", "Kubiak");
            r = new Record(30, "Nevermind", "Nirvana");
            rs = new RecordStatus(true, r, DateTime.Today);
            e = new Rent(c, rs, DateTime.Now, DateTime.Now.AddHours(5));
        }

        [Test]
        public void ServiceFindEvent()
        {
            DataRepository repo = new DataRepository(null);
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            Rent expected = new Rent(serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0), DateTime.Now);
            serv.GetRepo().AddEvent(expected);
            Rent actual = (Rent)serv.FindEvent(serv.GetRepo().GetRecordStatus(0));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ServiceEventsBetween()
        {
            DataRepository repo = new DataRepository(null);
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);

            DateTime rentDate = new DateTime(2024, 01, 03);
            DateTime dueDate = new DateTime(2024, 01, 04);

            Client c1 = new Client("A", "A");
            Record r1 = new Record(100, "B", "B");
            RecordStatus s1 = new RecordStatus(true, r1, DateTime.Now);
            serv.GetRepo().AddClient(c1);
            serv.GetRepo().AddRecord(r1);
            serv.GetRepo().AddRecordStatus(s1);

            Rent e1 = new Rent(c1, s1, rentDate, dueDate);
            serv.GetRepo().AddEvent(e1);

            Assert.AreEqual(1, serv.EventsBetween(new DateTime(2024, 01, 01), new DateTime(2024, 01, 05)).Count());
        }

        [Test]
        public void ServiceFindRecord()
        {
            DataRepository repo = new DataRepository(null);
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            Assert.AreSame(serv.GetRepo().GetRecord(0), serv.FindRecord(serv.GetRepo().GetRecordStatus(0)));
        }

        [Test]
        public void ServiceFindCustomerEvent()
        {
            DataRepository repo = new DataRepository(null);
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            Assert.AreEqual(e, serv.FindClientEvent(c));
        }

        [Test]

        public void ServiceRentRecord()
        {
            DataRepository repo = new DataRepository(null);
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            serv.RentRecord(serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0));
            Assert.False(serv.GetRepo().GetRecordStatus(0).available);
        }

        [Test]

        public void ServiceReturnRecord()
        {
            DataRepository repo = new DataRepository(null);
            repo.AddClient(c);
            repo.AddRecord(r);
            RecordStatus stat = new RecordStatus(false, repo.GetRecord(0), DateTime.Now);
            repo.AddRecordStatus(stat);
            var serv = IDataService.CreateService(repo);
            serv.ReturnRecord(serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0));
            Assert.True(serv.GetRepo().GetEvent(0).status.available);
        }

    }

}
