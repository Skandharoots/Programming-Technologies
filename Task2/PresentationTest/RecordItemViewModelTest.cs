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
    public class RecordItemViewModelTest
    {
        [TestMethod]
        public void RecordConstructorTest()
        {
            var recordItemViewModel = new RecordItemViewModel(0, "name", "title", new RecordModelMOCK());

            Assert.AreEqual(0, recordItemViewModel.RecordID);
            Assert.AreEqual("name", recordItemViewModel.Author);
            Assert.AreEqual("title", recordItemViewModel.Title);
        }

        [TestMethod]
        public void CheckIfCommandInitialized()
        {
            var recordItemViewModel = new RecordItemViewModel(0, "name", "title");

            var updateCommand = recordItemViewModel.UpdateCommand;

            Assert.IsNotNull(updateCommand);
        }

        [TestMethod]
        public void UpdateCorrectness()
        {
            var recordItemViewModel = new RecordItemViewModel(0, "name", "title");

            var updateCommand = recordItemViewModel.UpdateCommand;

            recordItemViewModel.Author = null;
            recordItemViewModel.Title = null;

            bool test = recordItemViewModel.CanUpdate;
            Assert.IsFalse(updateCommand.CanExecute(test));
        }
    }
}
