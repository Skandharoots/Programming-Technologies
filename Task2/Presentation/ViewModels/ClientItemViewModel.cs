using Presentation.ViewModels.MVVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.Implementation;
using Service.API;
using Presentation.Model.API;
using Presentation.Model;
using System.Configuration;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.ViewModels
{
    public class ClientItemViewModel :  ViewModelBase
    {
        private int clientID;
        private string name;
        private string surname;

        private IClientModel service;
        

        public ClientItemViewModel(int clientID, string name, string surname, IClientModel model = default(ClientModel))
        {
            this.clientID = clientID;
            this.name = name;
            this.surname = surname;
            service = model ?? new ClientModel();
            UpdateCommand = new RelayCommand(e => { UpdateClient(); }, c => CanUpdate);


        }

        public ClientItemViewModel()
        {
            service = new ClientModel();
            
            UpdateCommand = new RelayCommand(e => { UpdateClient(); }, c => CanUpdate);
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

        public ICommand UpdateCommand
        { get; }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(surname)
        );

        private void UpdateClient()
        {
            service.UpdateName(clientID, name);
            service.UpdateSurname(clientID, surname);
        }
    }
}
