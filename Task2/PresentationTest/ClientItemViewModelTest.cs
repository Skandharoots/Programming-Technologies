using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Presentation.ViewModels;
using Presentation.Model;
using Presentation.Model.API;
using Service.API;
using System.Linq;

namespace PresentationTest
{
    [TestClass]
    public class ClientItemViewModelTest
    {
        [TestMethod]
        public void ClientConstructorTest()
        {
            var clientItemViewModel = new ClientItemViewModel(0, "name", "surname", new ClientModelMOCK());

            Assert.AreEqual(0, clientItemViewModel.ClientID);
            Assert.AreEqual("name", clientItemViewModel.Name);
            Assert.AreEqual("surname", clientItemViewModel.Surname);
        }

        [TestMethod]
        public void CheckIfCommandInitialized()
        {
            var clientItemViewModel = new ClientItemViewModel(0, "name", "surname");

            var updateCommand = clientItemViewModel.UpdateCommand;

            Assert.IsNotNull(updateCommand);
        }

        [TestMethod]
        public void UpdateCorrectness()
        {
            var clientItemViewModel = new ClientItemViewModel(0, "name", "surname");

            var updateCommand = clientItemViewModel.UpdateCommand;

            clientItemViewModel.Name = null;
            clientItemViewModel.Surname = null;

            bool test = clientItemViewModel.CanUpdate;
            Assert.IsFalse(updateCommand.CanExecute(test));
        }
    }
}
