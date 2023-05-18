using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModels;

namespace PresentationTest
{
    [TestClass]
    public class ClientListViewModelTest
    {

        public ClientListViewModel SetViewModel()
        {
            return new ClientListViewModel()
            {
                ClientViewModels = new ObservableCollection<ClientItemViewModel>
                {
                    new ClientItemViewModel(1, "Marek", "Kopania"),
                    new ClientItemViewModel(2, "Mateusz", "Kubiak")
                }
            };
        }

        [TestMethod]
        public void InitialModelTest()
        {
            try
            {
                var clientListViewModel = SetViewModel();

                Assert.IsNull(clientListViewModel.SelectedVM);
                Assert.IsNotNull(clientListViewModel.AddCommand);
                Assert.IsNotNull(clientListViewModel.DeleteCommand);
            }
            catch (NullReferenceException) { }

        }

        [TestMethod]
        public void CountModelTest()
        {
            try
            {
                var clientListViewModel = SetViewModel();

                Assert.IsNotNull(clientListViewModel.ClientViewModels);
                Assert.AreEqual(clientListViewModel.ClientViewModels.Count, 2);
            }
            catch (NullReferenceException) { }

        }

        [TestMethod]
        public void DeleteTest()
        {
            try
            {
                var clientListViewModel = SetViewModel();
                clientListViewModel.SelectedVM = null;

                var deleteCommand = clientListViewModel.DeleteCommand;

                bool can = clientListViewModel.IsClientViewModelSelected;

                Assert.IsFalse(deleteCommand.CanExecute(can));
            }
            catch (NullReferenceException) { }

        }
    }
}
