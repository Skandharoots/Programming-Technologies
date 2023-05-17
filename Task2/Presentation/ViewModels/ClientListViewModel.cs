using Presentation.ViewModels.MVVN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Service.API;
using Presentation.Model.API;
using Presentation.Model;


namespace Presentation.ViewModels
{
    public class ClientListViewModel : ViewModelBase
    {
        private int clientID;
        private string name;
        private string surname;

        private ICommand addCommand;
        private ICommand deleteCommand;

        private IClientModel service;
        private ObservableCollection<ClientItemViewModel> clientViewModels;
        private ClientItemViewModel selectedViewModel;
        private bool isClientViewModelSelected;

        public ClientListViewModel()
        {
            service = new ClientModel();

            clientViewModels = new ObservableCollection<ClientItemViewModel>();

            addCommand = new RelayCommand(e => { AddClient(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteClient(); },
                condition => ClientViewModelIsSelected());

            IsClientViewModelSelected = true;

            GetClients();
        }

        private ClientItemViewModel Map(IClientModelData model) 
        {
            return model == null ? null : new ClientItemViewModel(model.Id, model.Name, model.Surname);
        }

        public void AddClient()
        {
            service.Add(clientID, name, surname);
            GetClients();
        }

        public void DeleteClient()
        {
            service.Delete(SelectedVM.ClientID);

            GetClients();
            OnPropertyChanged(nameof(clientViewModels));
        }

        public void GetClients()
        {
            clientViewModels.Clear();
           
            foreach (var c in service.Clients)
            {
                clientViewModels.Add(Map(c));
            }

            OnPropertyChanged(nameof(ClientViewModels));
        }

        public bool ClientViewModelIsSelected()
        {
            return !(selectedViewModel is null);
        }

        public int ClientID
        {
            get => clientID;
            set
            {
                clientID = value;

                OnPropertyChanged(nameof(clientID));
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
            string.IsNullOrWhiteSpace(clientID.ToString()) ||
            string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(surname)
        );
    }
}
