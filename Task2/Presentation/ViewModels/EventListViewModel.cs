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
    public class EventListViewModel : ViewModelBase
    {
        private int id;
        private int clientId;
        private int recordId;
        private DateTime purchaseDate;

        private ICommand addCommand;
        private ICommand deleteCommand;

        private IEventModel service;
        private ObservableCollection<EventItemViewModel> eventViewModels;
        private EventItemViewModel selectedViewModel;
        private bool isEventViewModelSelected;

        public EventListViewModel()
        {
            service = new EventModel();

            eventViewModels = new ObservableCollection<EventItemViewModel>();

            addCommand = new RelayCommand(e => { AddEvent(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteEvent(); },
                condition => EventViewModelIsSelected());

            IsEventViewModelSelected = true;

            GetEvents();
        }

        private EventItemViewModel Map(IEventModelData model)
        {
            return model == null ? null : new EventItemViewModel(model.Id, model.ClientId, model.StatusId, model.PurchaseDate);
        }

        public void AddEvent()
        {
            service.Add(id, clientId, recordId, purchaseDate);
            GetEvents();
        }

        public void DeleteEvent()
        {
            service.Delete(SelectedVM.EventID);

            GetEvents();
            OnPropertyChanged(nameof(eventViewModels));
        }

        public void GetEvents()
        {
            eventViewModels.Clear();

            foreach (var c in service.Events)
            {
                eventViewModels.Add(Map(c));
            }

            OnPropertyChanged(nameof(EventViewModels));
        }

        public bool EventViewModelIsSelected()
        {
            return !(selectedViewModel is null);
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

        public int StatusID
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

        public ICommand AddCommand
        {
            get => addCommand;
        }

        public ICommand DeleteCommand
        {
            get => deleteCommand;
        }

        public bool IsEventViewModelSelected
        {
            get => isEventViewModelSelected;
            set
            {
                isEventViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                isEventViewModelSelected = value;
                OnPropertyChanged(nameof(IsEventViewModelSelected));
            }
        }

        private Visibility isEventViewModelSelectedVisibility;

        public Visibility IsEventViewModelSelectedVisibility
        {
            get => isEventViewModelSelectedVisibility;
            set
            {
                isEventViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(isEventViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<EventItemViewModel> EventViewModels
        {
            get => eventViewModels;

            set
            {
                eventViewModels = value;
                OnPropertyChanged(nameof(eventViewModels));
            }
        }

        public EventItemViewModel SelectedVM
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                isEventViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(id.ToString()) ||
            string.IsNullOrWhiteSpace(clientId.ToString()) ||
            string.IsNullOrWhiteSpace(recordId.ToString()) ||
            string.IsNullOrWhiteSpace(purchaseDate.ToString())
        );
    }
}
