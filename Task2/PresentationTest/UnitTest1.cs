using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Presentation.ViewModels;
using Presentation.Model;
using Presentation.Model.API;
using Service.API;
using Service.Implementation;
using System.Linq;

namespace PresentationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IClientModel model = new ClientModel(new ClientCRUD());
            Assert.IsNotNull(model.Clients);
         
            
        }
    }
}
