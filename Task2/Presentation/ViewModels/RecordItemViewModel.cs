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
    public class RecordItemViewModel : ViewModelBase
    {
        private int id;
        private string author;
        private string title;

        private readonly IRecordModel service;


        public RecordItemViewModel(int recordId, string author, string title, IRecordModel model = default(RecordModel))
        {
            this.id = recordId;
            this.author = author;
            this.title = title;
            service = model ?? new RecordModel();
            UpdateCommand = new RelayCommand(e => { UpdateRecord(); }, c => CanUpdate);


        }

        public RecordItemViewModel()
        {
            service = new RecordModel();
            UpdateCommand = new RelayCommand(e => { UpdateRecord(); }, c => CanUpdate);
        }



        public int RecordID
        {
            get => id;

            set
            {
                id = value;
                OnPropertyChanged(nameof(id));
            }
        }

        public string Author
        {
            get => author;
            set
            {
                author = value;

                OnPropertyChanged(nameof(author));
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;

                OnPropertyChanged(nameof(title));
            }
        }

        public ICommand UpdateCommand { get; }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(author) ||
            string.IsNullOrWhiteSpace(title)
        );

        private void UpdateRecord()
        {
            service.UpdateAuthor(id, author);
            service.UpdateTitle(id, title);
        }
    }
}

