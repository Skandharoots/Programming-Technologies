using Presentation.ViewModel.MVVN;
using Presentation.ViewModel;
using Service.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class ClientListViewModel : ViewModelBase
    {
        private int id;
        private string name;
        private string surname;

        private ICommand addCommand;
        private ICommand deleteCommand;

        private IClientCRUD service;
        private ObservableCollection<ClientItemViewModel> clientViewModels;
        private ClientItemViewModel selectedViewModel;
        private bool isClientViewModelSelected;

        public ClientListViewModel()
        {
            service = IClientCRUD.Create();
            clientViewModels = new ObservableCollection<ClientItemViewModel>();

            addCommand = new RelayCommand(e => { AddClient(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteClient(); },
                condition => ClientViewModelIsSelected());

            IsClientViewModelSelected = false;

            GetClients();
        }

        private void AddClient()
        {
            service.AddClient(name, surname);
            GetClients();
        }

        private void DeleteClient()
        {
            service.DeleteClient(SelectedVM.Id);

            GetClients();
            OnPropertyChanged(nameof(clientViewModels));
        }

        private void GetClients()
        {
            clientViewModels.Clear();

            foreach (var c in service.GetAllClients())
            {
                clientViewModels.Add(new ClientItemViewModel(c.Id, c.Name, c.Surname));
            }

            OnPropertyChanged(nameof(ClientViewModels));
        }

        private bool ClientViewModelIsSelected()
        {
            return !(selectedViewModel is null);
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;

                OnPropertyChanged(nameof(id));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;

                OnPropertyChanged(nameof(name));
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;

                OnPropertyChanged(nameof(surname));
            }
        }

        public ICommand AddCommand
        {
            get => addCommand;
        }

        public ICommand DeleteCommand
        {
            get => deleteCommand;
        }

        public bool IsClientViewModelSelected
        {
            get => isClientViewModelSelected;
            set
            {
                isClientViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                isClientViewModelSelected = value;
                OnPropertyChanged(nameof(IsClientViewModelSelected));
            }
        }

        private Visibility isClientViewModelSelectedVisibility;

        public Visibility IsClientViewModelSelectedVisibility
        {
            get => isClientViewModelSelectedVisibility;
            set
            {
                isClientViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(isClientViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<ClientItemViewModel> ClientViewModels
        {
            get => clientViewModels;

            set
            {
                clientViewModels = value;
                OnPropertyChanged(nameof(clientViewModels));
            }
        }

        public ClientItemViewModel SelectedVM
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                isClientViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(surname)
        );
    }
}
