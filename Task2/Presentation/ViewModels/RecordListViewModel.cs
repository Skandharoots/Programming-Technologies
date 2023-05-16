using Presentation.Model.API;
using Presentation.Model;
using Presentation.ViewModels.MVVN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Presentation.ViewModels
{
    public class RecordListViewModel : ViewModelBase
    {
        private int id;
        private string author;
        private string title;

        private ICommand addCommand;
        private ICommand deleteCommand;

        private IRecordModel service;
        private ObservableCollection<RecordItemViewModel> recordViewModels;
        private RecordItemViewModel selectedViewModel;
        private bool isRecordViewModelSelected;

        public RecordListViewModel()
        {
            service = new RecordModel();

            recordViewModels = new ObservableCollection<RecordItemViewModel>();

            addCommand = new RelayCommand(e => { AddRecord(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteRecord(); },
                condition => RecordViewModelIsSelected());

            IsRecordViewModelSelected = true;

            GetRecords();
        }

        private RecordItemViewModel Map(IRecordModelData model)
        {
            return model == null ? null : new RecordItemViewModel(model.Id, model.Author, model.Title);
        }

        public void AddRecord()
        {
            service.Add(id, author, title);
            GetRecords();
        }

        public void DeleteRecord()
        {
            service.Delete(SelectedVM.RecordID);

            GetRecords();
            OnPropertyChanged(nameof(recordViewModels));
        }

        public void GetRecords()
        {
            recordViewModels.Clear();

            foreach (var c in service.Records)
            {
                recordViewModels.Add(Map(c));
            }

            OnPropertyChanged(nameof(RecordViewModels));
        }

        public bool RecordViewModelIsSelected()
        {
            return !(selectedViewModel is null);
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

        public ICommand AddCommand
        {
            get => addCommand;
        }

        public ICommand DeleteCommand
        {
            get => deleteCommand;
        }

        public bool IsRecordViewModelSelected
        {
            get => isRecordViewModelSelected;
            set
            {
                isRecordViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                isRecordViewModelSelected = value;
                OnPropertyChanged(nameof(IsRecordViewModelSelected));
            }
        }

        private Visibility isRecordViewModelSelectedVisibility;

        public Visibility IsRecordViewModelSelectedVisibility
        {
            get => isRecordViewModelSelectedVisibility;
            set
            {
                isRecordViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(isRecordViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<RecordItemViewModel> RecordViewModels
        {
            get => recordViewModels;

            set
            {
                recordViewModels = value;
                OnPropertyChanged(nameof(recordViewModels));
            }
        }

        public RecordItemViewModel SelectedVM
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                isRecordViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(author) ||
            string.IsNullOrWhiteSpace(title)
        );
    }
}

