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
    public class RecordStatusItemViewModel : ViewModelBase
    {
        private int id;
        private int recordId;
        private bool sold;

        private readonly IRecordStatusModel service;


        public RecordStatusItemViewModel(int Id, int recordId, bool sold, IRecordStatusModel model = default(RecordStatusModel))
        {
            this.id = Id;
            this.recordId = recordId;
            this.sold = sold;
            service = model ?? new RecordStatusModel();
            UpdateCommand = new RelayCommand(e => { UpdateRecordStatus(); }, c => CanUpdate);


        }

        public RecordStatusItemViewModel()
        {
            service = new RecordStatusModel();
            UpdateCommand = new RelayCommand(e => { UpdateRecordStatus(); }, c => CanUpdate);
        }



        public int RecordStatusID
        {
            get => id;

            set
            {
                id = value;
                OnPropertyChanged(nameof(id));
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

        public bool Sold
        {
            get => sold;
            set
            {
                sold = value;

                OnPropertyChanged(nameof(sold));
            }
        }

        public ICommand UpdateCommand { get; }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(recordId.ToString()) ||
            string.IsNullOrWhiteSpace(sold.ToString())
        );

        private void UpdateRecordStatus()
        {
            service.UpdateRecord(id, recordId);
            service.UpdateSold(id, sold);
        }
    }
}

