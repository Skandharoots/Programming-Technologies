using Presentation.ViewModel.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Presentation.Model.API;
using Presentation.Model;

namespace Presentation.ViewModel
{
    public class UserListViewModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _surname;

        private readonly IClientModel _model;
        private ObservableCollection<ClientItemViewModel> _clientViewModels;
        private ClientItemViewModel _selectedViewModel;
        private bool _isClientViewModelSelected;

        private Visibility _isClientViewModelSelectedVisibility;

        public UserListViewModel(IClientModel model = default(ClientModel))
        {
            _model = model ?? new ClientModel();
            _clientViewModels = new ObservableCollection<ClientItemViewModel>();

            AddCommand = new RelayCommand(e => { AddClient(); }, _ => CanAdd);

            DeleteCommand = new RelayCommand(e => { DeleteClient(); }, _ => ClientViewModelIsSelected());

            IsClientViewModelSelected = false;

            GetClients();
        }


        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        private void AddClient()
        {
            _model.Add(_id, _name, _surname);
            GetClients();
        }

        private void DeleteClient()
        {
            _model.Delete(SelectedVm.Id);

            GetClients();
            OnPropertyChanged(nameof(ClientViewModels));
        }

        private void GetClients()
        {
            _clientViewModels.Clear();

            foreach (var c in _model.Clients)
            {
                _clientViewModels.Add(new ClientItemViewModel(c.Id, c.Name, c.Surname));
            }

            OnPropertyChanged(nameof(ClientViewModels));
        }

        private bool ClientViewModelIsSelected()
        {
            return _selectedViewModel != null;
        }

        public int Id
        {
            get => _id;
            set
            {
                _id = value;

                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;

                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;

                OnPropertyChanged(nameof(Surname));
            }
        }

        public bool IsClientViewModelSelected
        {
            get => _isClientViewModelSelected;
            set
            {
                IsClientViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                _isClientViewModelSelected = value;
                OnPropertyChanged(nameof(IsClientViewModelSelected));
            }
        }

        public Visibility IsClientViewModelSelectedVisibility
        {
            get => _isClientViewModelSelectedVisibility;
            set
            {
                _isClientViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(IsClientViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<ClientItemViewModel> ClientViewModels
        {
            get => _clientViewModels;

            set
            {
                _clientViewModels = value;
                OnPropertyChanged(nameof(ClientViewModels));
            }
        }

        public ClientItemViewModel SelectedVm
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                IsClientViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVm));
            }
        }

        public bool CanAdd => !(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname));
    }
}
