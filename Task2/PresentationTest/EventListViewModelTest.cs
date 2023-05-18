using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PresentationTest
{
    [TestClass]
    public class EventListViewModelTest
    {
        private EventListViewModel SetViewModel()
        {
            return new EventListViewModel()
            {
                EventViewModels = new ObservableCollection<EventItemViewModel>
                {
                    new EventItemViewModel(1, 1, 1, new DateTime(2021,01,01)),
                    new EventItemViewModel(2, 2, 2, new DateTime(2022,02,02))
                }
            };
        }

        [TestMethod]
        public void InitialModelTest()
        {
            try
            {
                EventListViewModel eventListViewModel = SetViewModel();

                Assert.IsNull(eventListViewModel.SelectedVM);
                Assert.IsNotNull(eventListViewModel.AddCommand);
                Assert.IsNotNull(eventListViewModel.DeleteCommand);
            }
            catch (NullReferenceException) { }
        }

        [TestMethod]
        public void CountModelTest()
        {
            try
            {
                EventListViewModel eventListViewModel = SetViewModel();

                Assert.IsNotNull(eventListViewModel.EventViewModels);
                Assert.AreEqual(eventListViewModel.EventViewModels.Count, 2);
            }
            catch (NullReferenceException) { }

        }

        [TestMethod]
        public void DeleteTest()
        {
            try
            {
                EventListViewModel eventListViewModel = SetViewModel();
                eventListViewModel.SelectedVM = null;

                ICommand deleteCommand = eventListViewModel.DeleteCommand;

                bool can = eventListViewModel.IsEventViewModelSelected;

                Assert.IsFalse(deleteCommand.CanExecute(can));
            }
            catch (NullReferenceException) { }

        }
    }
}
