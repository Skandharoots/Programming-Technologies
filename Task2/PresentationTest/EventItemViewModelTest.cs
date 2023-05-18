using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;

namespace PresentationTest
{
    [TestClass]
    public class EventItemViewModelTest
    {
        public void EventConstructorTest()
        {
            DateTime time = new DateTime(2020, 05, 15);
            var eventItemViewModel = new EventItemViewModel(0, 1, 1, time, new EventModelMOCK());

            Assert.AreEqual(0, eventItemViewModel.EventID);
            Assert.AreEqual(1, eventItemViewModel.ClientID);
            Assert.AreEqual(1, eventItemViewModel.RecordID);
            Assert.AreEqual(time, eventItemViewModel.PurchaseDate);
        }

        [TestMethod]
        public void CheckIfCommandInitialized()
        {
            var eventItemViewModel = new EventItemViewModel(0, 1, 1, DateTime.Now, new EventModelMOCK());

            var updateCommand = eventItemViewModel.UpdateCommand;

            Assert.IsNotNull(updateCommand);
        }

        [TestMethod]
        public void UpdateCorrectness()
        {
            var eventItemViewModel = new EventItemViewModel(0, 1, 1, DateTime.Now, new EventModelMOCK());
            var updateCommand = eventItemViewModel.UpdateCommand;
            bool test = eventItemViewModel.CanUpdate;
            Assert.IsTrue(updateCommand.CanExecute(test));
        }
    }
}
