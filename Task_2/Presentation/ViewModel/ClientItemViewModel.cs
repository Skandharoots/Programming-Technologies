using Presentation.ViewModel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.Model.API;
using Presentation.Model;

namespace Presentation.ViewModel
{
    public class ClientItemViewModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _surname;

        private readonly IClientModel _model;

        public ClientItemViewModel(int id, string firstName = null, string surname = null)
        {
            _id = id;
            _name = firstName;
            _surname = surname;

            
        }

        public ClientItemViewModel() 
        {
            _model = new ClientModel();
            UpdateCommand = new RelayCommand(_ => { UpdateClient(); }, c => CanUpdate);
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

        public ICommand UpdateCommand { get; }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(Name) ||
            string.IsNullOrWhiteSpace(Surname)
        );

        private void UpdateClient()
        {
            _model.UpdateClient(Id, Name, Surname);
        }
    }
}
