using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;
using Presentation.Model;
using System.Windows.Input;
using Presentation.ViewModels.MVVN;

namespace Presentation.ViewModels
{
    public class EventItemViewModel : ViewModelBase
    {
        private int id;
        private int clientId;
        private int recordId;
        private DateTime purchaseDate;

        private readonly IEventModel service;


        public EventItemViewModel(int id, int clientId, int recordId, DateTime time, IEventModel model = default(EventModel))
        {
            this.id = id;
            this.clientId = clientId;
            this.recordId = recordId;
            this.purchaseDate = time;
            service = model ?? new EventModel();
            UpdateCommand = new RelayCommand(e => { UpdateEvent(); }, c => CanUpdate);


        }

        public EventItemViewModel()
        {
            service = new EventModel();
            UpdateCommand = new RelayCommand(e => { UpdateEvent(); }, c => CanUpdate);
        }



        public int EventID
        {
            get => id;

            set
            {
                id = value;
                OnPropertyChanged(nameof(id));
            }
        }

        public int ClientID
        {
            get => clientId;

            set
            {
                clientId = value;
                OnPropertyChanged(nameof(clientId));
                
            }
        }

        public int RecordID
        {
            get => recordId;
            set
            {
                recordId = value;
                OnPropertyChanged(nameof(recordId));
            }
        }

        public DateTime PurchaseDate
        {
            get => purchaseDate;
            set
            {
                purchaseDate = value;
                OnPropertyChanged(nameof(purchaseDate));
            }
        }

        public ICommand UpdateCommand { get; }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(clientId.ToString()) ||
            string.IsNullOrWhiteSpace(recordId.ToString()) ||
            string.IsNullOrWhiteSpace(purchaseDate.ToString())
        );

        private void UpdateEvent()
        {
            service.UpdateClient(id, clientId);
            service.UpdateStatus(id, recordId);
            service.UpdatePurchaseDate(id, purchaseDate);
        }
    }
}
