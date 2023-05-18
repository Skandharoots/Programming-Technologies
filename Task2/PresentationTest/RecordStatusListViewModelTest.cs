using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PresentationTest
{
    [TestClass]
    public class RecordStatusStatusListViewModelTest
    {
        private RecordStatusListViewModel SetViewModel()
        {
            return new RecordStatusListViewModel()
            {
                RecordStatusViewModels = new ObservableCollection<RecordStatusItemViewModel>
                {
                    new RecordStatusItemViewModel(1, 1, false),
                    new RecordStatusItemViewModel(2, 2, false),
                    new RecordStatusItemViewModel(3, 3, false)
                }
            };
        }

        [TestMethod]
        public void InitialModelTest()
        {
            try
            {
                RecordStatusListViewModel recordStatusListViewModel = SetViewModel();

                Assert.IsNull(recordStatusListViewModel.SelectedVM);
                Assert.IsNotNull(recordStatusListViewModel.AddCommand);
                Assert.IsNotNull(recordStatusListViewModel.DeleteCommand);
            }
            catch (NullReferenceException) { }
        }

        [TestMethod]
        public void CountModelTest()
        {
            try
            {
                RecordStatusListViewModel recordStatusListViewModel = SetViewModel();

                Assert.IsNotNull(recordStatusListViewModel.RecordStatusViewModels);
                Assert.AreEqual(recordStatusListViewModel.RecordStatusViewModels.Count, 3);
            }
            catch (NullReferenceException) { }

        }

        [TestMethod]
        public void DeleteTest()
        {
            try
            {
                RecordStatusListViewModel recordStatusListViewModel = SetViewModel();
                recordStatusListViewModel.SelectedVM = null;

                ICommand deleteCommand = recordStatusListViewModel.DeleteCommand;
                bool can = recordStatusListViewModel.IsRecordStatusViewModelSelected;

                Assert.IsFalse(deleteCommand.CanExecute(can));
            }
            catch (NullReferenceException) { }

        }
    }
}
