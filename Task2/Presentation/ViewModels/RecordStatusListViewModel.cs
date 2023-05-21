using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model.API;
using Presentation.Model;
using System.Windows.Input;
using System.Windows;
using Presentation.ViewModels.MVVN;

namespace Presentation.ViewModels
{
    public class RecordStatusListViewModel : ViewModelBase
    {
        private int id;
        private int recordId;
        private bool sold;

        private ICommand addCommand;
        private ICommand deleteCommand;

        private IRecordStatusModel service;
        private ObservableCollection<RecordStatusItemViewModel> recordStatusViewModels;
        private RecordStatusItemViewModel selectedViewModel;
        private bool isRecordStatusViewModelSelected;

        public RecordStatusListViewModel()
        {
            service = new RecordStatusModel();

            recordStatusViewModels = new ObservableCollection<RecordStatusItemViewModel>();

            addCommand = new RelayCommand(e => { AddRecordStatus(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteRecordStatus(); },
                condition => RecordStatusViewModelIsSelected());

            IsRecordStatusViewModelSelected = true;

            GetRecordStatuses();
        }

        public RecordStatusListViewModel(IRecordStatusModel model = default(RecordStatusModel))
        {
            service = model ?? new RecordStatusModel();
            recordStatusViewModels = new ObservableCollection<RecordStatusItemViewModel>();

            addCommand = new RelayCommand(e => { AddRecordStatus(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteRecordStatus(); },
                condition => RecordStatusViewModelIsSelected());

            IsRecordStatusViewModelSelected = true;

            GetRecordStatuses();
        }

        private RecordStatusItemViewModel Map(IRecordStatusModelData model)
        {
            return model == null ? null : new RecordStatusItemViewModel(model.Id, model.RecordId, model.Sold);
        }

        public void AddRecordStatus()
        {
            service.Add(id, recordId, sold);
            GetRecordStatuses();
        }

        public void DeleteRecordStatus()
        {
            service.Delete(SelectedVM.RecordID);

            GetRecordStatuses();
            OnPropertyChanged(nameof(recordStatusViewModels));
        }

        public void GetRecordStatuses()
        {
            recordStatusViewModels.Clear();

            foreach (var c in service.Statuses)
            {
                recordStatusViewModels.Add(Map(c));
            }

            OnPropertyChanged(nameof(RecordStatusViewModels));
        }

        public bool RecordStatusViewModelIsSelected()
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

        public int RecordId
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

        public ICommand AddCommand
        {
            get => addCommand;
        }

        public ICommand DeleteCommand
        {
            get => deleteCommand;
        }

        public bool IsRecordStatusViewModelSelected
        {
            get => isRecordStatusViewModelSelected;
            set
            {
                isRecordStatusViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                isRecordStatusViewModelSelected = value;
                OnPropertyChanged(nameof(IsRecordStatusViewModelSelected));
            }
        }

        private Visibility isRecordStatusViewModelSelectedVisibility;

        public Visibility IsRecordStatusViewModelSelectedVisibility
        {
            get => isRecordStatusViewModelSelectedVisibility;
            set
            {
                isRecordStatusViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(isRecordStatusViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<RecordStatusItemViewModel> RecordStatusViewModels
        {
            get => recordStatusViewModels;

            set
            {
                recordStatusViewModels = value;
                OnPropertyChanged(nameof(recordStatusViewModels));
            }
        }

        public RecordStatusItemViewModel SelectedVM
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                isRecordStatusViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(recordId.ToString()) ||
            string.IsNullOrWhiteSpace(sold.ToString())
        );
    }
}

