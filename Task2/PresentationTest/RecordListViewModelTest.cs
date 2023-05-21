using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Presentation.ViewModels;

namespace PresentationTest
{
    [TestClass]
    public class RecordListViewModelTest
    {
        private RecordListViewModel SetViewModel()
        {
            return new RecordListViewModel(new RecordModelMOCK())
            {
                RecordViewModels = new ObservableCollection<RecordItemViewModel>
                {
                    new RecordItemViewModel(1, "Nirvana", "Nevermind"),
                    new RecordItemViewModel(2, "Tam Impala", "Currents"),
                    new RecordItemViewModel(3, "Mac Demarco", "Salad Days")
                }
            };
        }

        [TestMethod]
        public void InitialModelTest()
        {
            try
            {
                RecordListViewModel recordListViewModel = SetViewModel();

                Assert.IsNull(recordListViewModel.SelectedVM);
                Assert.IsNotNull(recordListViewModel.AddCommand);
                Assert.IsNotNull(recordListViewModel.DeleteCommand);
            }
            catch (NullReferenceException) { }
        }

        [TestMethod]
        public void CountModelTest()
        {
            try
            {
                RecordListViewModel recordListViewModel = SetViewModel();

                Assert.IsNotNull(recordListViewModel.RecordViewModels);
                Assert.AreEqual(recordListViewModel.RecordViewModels.Count, 3);
            }
            catch (NullReferenceException) { }

        }

        [TestMethod]
        public void DeleteTest()
        {
            try
            {
                RecordListViewModel recordListViewModel = SetViewModel();
                recordListViewModel.SelectedVM = null;

                ICommand deleteCommand = recordListViewModel.DeleteCommand;
                bool can = recordListViewModel.IsRecordViewModelSelected;

                Assert.IsFalse(deleteCommand.CanExecute(can));
            }
            catch (NullReferenceException) { }

        }
    }
}
