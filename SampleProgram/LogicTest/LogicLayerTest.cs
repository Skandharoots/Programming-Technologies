using Data.API;
using Logic.API;
using Logic.Implementation;
using NSubstitute;

namespace TestLibrary
{

    public class LogicLayerTest
    {


        private IClient c;
        private IRecord r;
        private IRecordStatus rs;
        private IEvent e;


        public LogicLayerTest()
        {
            c = new Client("Mateusz", "Kubiak");
            r = new Record(30, "Nevermind", "Nirvana");
            rs = new RecordStatus(true, r, DateTime.Today);
            e = IEvent.CreateEvent(IEvent.Eventkind.rent, c, rs);
        }

        [Test]
        public void ServiceFindEvent()
        {
            IDataRepository repo = IDataRepository.CreateRepo();
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            repo.AddEvent(e);
            var serv = IDataService.CreateService(repo);
            IEvent expected = IEvent.CreateEvent(IEvent.Eventkind.rent, serv.GetRepo().GetClient(0), serv.GetRepo().GetRecordStatus(0));
            serv.GetRepo().AddEvent(expected);
            IEvent actual = serv.FindEvent(serv.GetRepo().GetRecordStatus(0));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ServiceEventsBetween()
        {
            IDataRepository repo = IDataRepository.CreateRepo();
            repo.AddClient(c);
            repo.AddRecord(r);
            repo.AddRecordStatus(rs);
            var serv = IDataService.CreateService(repo);
            IClient c1 = new Client("A", "A");
            IRecord r1 = new Record(100, "B", "B");
            IRecordStatus s1 = new RecordStatus(true, r1, DateTime.Now);
            serv.GetRepo().AddClient(c1);
            serv.GetRepo().AddRecord(r1);
            serv.GetRepo().AddRecordStatus(s1);
            IEvent e1 = IEvent.CreateEvent(IEvent.Eventkind.rent, c1, s1);
            serv.GetRepo().AddEvent(e1);
            Assert.AreEqual(1, serv.EventsBetween(DateTime.Now.AddMinutes(-2), DateTime.Now.AddDays(10)).Count());
        }

        [Test]
        public void ServiceFindRecord()
        {
            IDataRepository repo = IDataRepository.CreateRepo();
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
            IDataRepository repo = IDataRepository.CreateRepo();
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
            IDataRepository repo = IDataRepository.CreateRepo();
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
            IDataRepository repo = IDataRepository.CreateRepo();
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
