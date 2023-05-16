using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.API;
using Service.Implementation;
using System.Linq;
using System.Runtime.InteropServices;

namespace ServiceTest
{
    [TestClass]
    public class ClientServiceTest
    {



        [TestMethod]
        public void TestAddDeleteClient()
        {
            IClientCRUD clientService = new ClientCRUD(new DataLayerMock());
            clientService.AddClient(1, "Marek", "Kopania");
            Assert.IsNotNull(clientService.GetClient(1));
            clientService.DeleteClient(1);

        }

        [TestMethod]
        public void TestUpdateClient() 
        {
            IClientCRUD clientService = new ClientCRUD(new DataLayerMock());
            clientService.AddClient(1, "Marek", "Kopania");
            clientService.UpdateClientName(1, "Konrad");
            Assert.AreEqual(clientService.GetClient(1).Name, "Konrad");
            clientService.DeleteClient(1);
        }

        [TestMethod]
        public void TestGetAllClients() 
        {
            IClientCRUD clientService = new ClientCRUD(new DataLayerMock());
            clientService.AddClient(1, "Marek", "Kopania");
            Assert.AreEqual(1, clientService.GetAllClients().Count());
        }
    }
}