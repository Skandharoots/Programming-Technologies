using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class FillConstantValuesTest
    {
        [Test]

        public void testConstFill()
        {
            var datarepo = IDataRepository.CreateRepo(new FillConstantValues());
            Assert.AreEqual("Marek", datarepo.GetClient(0).Name);
            Assert.AreNotEqual(8, datarepo.GetAllClients().Count());
            Assert.AreEqual("Nevermind", datarepo.GetRecord(0).Author);
            Assert.AreNotEqual(7, datarepo.GetAllRecords().Count());
            Assert.AreEqual(datarepo.GetRecord(0), datarepo.GetRecordStatus(0).record);
            Assert.AreNotEqual(6, datarepo.GetAllRecordStatus().Count());
        }
    }
}
