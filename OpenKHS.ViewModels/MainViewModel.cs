using System;
using System.ComponentModel;
using Savaged.BusyStateManager;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Models;
using System.Threading.Tasks;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private int _selectedIndex;

        public MainViewModel(
            IBusyStateRegistry busyStateManager,
            MasterDetailViewModel<ClmmSchedule> clmmScheduleAdminViewModel,
            MasterDetailViewModel<PmSchedule> pmScheduleAdminViewModel,
            MasterDetailViewModel<Assignee> assigneeAdminViewModel,
            IndexViewModel<AssignmentType> assignmentTypesViewModel)
            : base(busyStateManager)
        {
            ClmmScheduleAdminViewModel = clmmScheduleAdminViewModel ??
                throw new ArgumentNullException(nameof(clmmScheduleAdminViewModel));
            PmScheduleAdminViewModel = pmScheduleAdminViewModel ??
                throw new ArgumentNullException(nameof(pmScheduleAdminViewModel));
            AssigneeAdminViewModel = assigneeAdminViewModel ??
                throw new ArgumentNullException(nameof(assigneeAdminViewModel));
            AssignmentTypesViewModel = assignmentTypesViewModel ??
                throw new ArgumentNullException(nameof(assignmentTypesViewModel));

            ReloadCmd = new RelayCommand(OnReload, () => CanExecute);

            BusyStateManager.PropertyChanged += OnBusyStateManagerPropertyChanged;
            PropertyChanged += OnPropertyChanged;
        }

        public int SelectedIndex 
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }

        public ICommand ReloadCmd { get; }

        public MasterDetailViewModel<Assignee> AssigneeAdminViewModel
        { get; }

        public MasterDetailViewModel<ClmmSchedule> ClmmScheduleAdminViewModel
        { get; }

        public MasterDetailViewModel<PmSchedule> PmScheduleAdminViewModel
        { get; }

        public IndexViewModel<AssignmentType> AssignmentTypesViewModel 
        { get; }

        public async Task LoadAsync()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            await ClmmScheduleAdminViewModel.LoadAsync();
            MessengerInstance.Send(new BusyMessage(false, this));
        }

        private void OnReload()
        {
            SelectedIndex = 0;
        }

        private async void OnPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedIndex))
            {
                MessengerInstance.Send(new BusyMessage(true, this));
                switch (SelectedIndex)
                {
                    case 0:
                        await ClmmScheduleAdminViewModel.LoadAsync();
                        break;
                    case 1:
                        await PmScheduleAdminViewModel.LoadAsync();
                        break;
                    case 2: 
                        await AssigneeAdminViewModel.LoadAsync();
                        break;
                    case 3: 
                        await AssignmentTypesViewModel.LoadAsync();
                        break;
                }
                MessengerInstance.Send(new BusyMessage(false, this));
            }
        }

        private void OnBusyStateManagerPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IBusyStateRegistry.IsBusy))
            {
                var isBusy = BusyStateManager.IsBusy;
                SetIsBusy(isBusy, this);
            }
        }

    }
}
