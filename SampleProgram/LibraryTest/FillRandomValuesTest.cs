using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    internal class FillRandomValuesTest
    {
        [Test]

        public void testConstFill()
        {
            var datarepo = IDataRepository.CreateRepo(new FillRandomValues());
            Assert.AreEqual(30, datarepo.GetAllClients().Count());
            Assert.AreNotEqual(8, datarepo.GetAllClients().Count());
            Assert.AreEqual(10, datarepo.GetAllRecords().Count());
            Assert.AreNotEqual(7, datarepo.GetAllRecords().Count());
            Assert.AreEqual(10, datarepo.GetAllRecordStatus().Count());
            Assert.AreNotEqual(6, datarepo.GetAllRecordStatus().Count());
            Assert.AreEqual(30, datarepo.GetAllEvents().Count());
        }
    }
}
