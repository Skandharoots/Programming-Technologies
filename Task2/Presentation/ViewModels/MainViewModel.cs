using Presentation.ViewModels.MVVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _viewModel;
        private ICommand _command;

        public MainViewModel()
        {
            ViewModel = new ClientListViewModel();
            _command = new RelayCommand(view => { SwitchView(view.ToString()); });
        }
        public ViewModelBase ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged(nameof(ViewModel));
            }
        }

        public ICommand command
        {

            get => _command;

        }
        public void SwitchView(string view)
        {
            switch (view)
            {
                case "ClientListView":
                    ViewModel = new ClientListViewModel();
                    break;
                case "RecordListView":
                    ViewModel = new RecordListViewModel();
                    break;
                

            }
        }


    }
}
