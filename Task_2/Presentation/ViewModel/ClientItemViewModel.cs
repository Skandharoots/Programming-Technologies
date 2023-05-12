using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.ViewModel.MVVN;
using Service.API;

namespace Presentation.ViewModel
{
    public class ClientItemViewModel : ViewModelBase
    {
        private int id;
        private string name;
        private string surname;

        private IClientCRUD service;
        private ICommand updateCommand;

        public ClientItemViewModel(int clientID, string name, string surname)
        {
            this.id = clientID;
            this.name = name;
            this.surname = surname;
        }

        public ClientItemViewModel()
        {
            service = IClientCRUD.Create();
            updateCommand = new RelayCommand(e => { UpdateClient(); }, c => CanUpdate);
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

        public ICommand UpdateCommand
        {
            get => updateCommand;
        }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(surname)
        );

        private void UpdateClient()
        {
            service.UpdateClientName(id, name);
            service.UpdateClientSurname(id, surname);
        }
    }
}