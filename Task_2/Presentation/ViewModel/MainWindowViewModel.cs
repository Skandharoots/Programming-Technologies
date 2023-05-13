using Presentation.ViewModel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.ViewModel;

namespace Presentation.ViewModel
{

    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase _selectedVm;
        public ICommand _SwitchViewCommand;

        public MainWindowViewModel()
        {
            SelectedVm = new ClientListViewModel();
            _SwitchViewCommand = new RelayCommand(view => { SwitchView(view.ToString()); });
        }

        public ViewModelBase SelectedVm
        {
            get => _selectedVm;
            set
            {
                _selectedVm = value;
                OnPropertyChanged(nameof(SelectedVm));
            }
        }

        public ICommand SwitchViewCommand => _SwitchViewCommand;

        public void SwitchView(string view)
        {
            switch (view)
            {
                case "UserListView":
                    SelectedVm = new ClientListViewModel();
                    break;
                
            }
        }
    }
}