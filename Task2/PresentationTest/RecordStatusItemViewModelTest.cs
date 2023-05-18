using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTest
{
    [TestClass]
    public class RecordStatusItemViewModelTest
    {
        [TestMethod]
        public void RecordStatusConstructorTest()
        {
            var recordStatusItemViewModel = new RecordStatusItemViewModel(0, 1, true, new RecordStatusModelMOCK());

            Assert.AreEqual(0, recordStatusItemViewModel.RecordStatusID);
            Assert.AreEqual(1, recordStatusItemViewModel.RecordID);
            Assert.AreEqual(true, recordStatusItemViewModel.Sold);
        }

        [TestMethod]
        public void CheckIfCommandInitialized()
        {
            var recordStatusItemViewModel = new RecordStatusItemViewModel(0, 1, true);

            var updateCommand = recordStatusItemViewModel.UpdateCommand;

            Assert.IsNotNull(updateCommand);
        }

        [TestMethod]
        public void CanUpdateTest()
        {
            var recordStatusItemViewModel = new RecordStatusItemViewModel(0, 1, true);
            var updateCommand = recordStatusItemViewModel.UpdateCommand;
            bool test = recordStatusItemViewModel.CanUpdate;
            Assert.IsTrue(updateCommand.CanExecute(test));
        }
    }
}
