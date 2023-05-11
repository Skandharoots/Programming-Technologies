using Service.API;
using Service.Implementation;

namespace ServiceTest
{
    [TestClass]
    public class ClientServiceTest
    {
        

        [TestMethod]
        public void TestAddDeleteClient()
        {
            IClientCRUD clientService = IClientCRUD.CreateClient(new DataLayerMock());
            clientService.AddClient("Marek", "Kopania");
            Assert.IsNotNull(clientService.GetClient(1));
            clientService.DeleteClient(1);

        }
    }
}