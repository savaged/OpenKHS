using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OpenKHS.Models;
using Savaged.BusyStateManager;

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

        public void Load()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            ClmmScheduleAdminViewModel.Load();
            Thread.Sleep(5000);
            MessengerInstance.Send(new BusyMessage(false, this));
        }

        private void OnReload()
        {
            SelectedIndex = 0;
        }

        private void OnPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            switch (SelectedIndex)
            {
                case 0:
                    ClmmScheduleAdminViewModel.Load();
                    break;
                case 1:
                    PmScheduleAdminViewModel.Load();
                    break;
                case 2: 
                    AssigneeAdminViewModel.Load();
                    break;
                case 3: 
                    AssignmentTypesViewModel.Load();
                    break;
            }
            MessengerInstance.Send(new BusyMessage(false, this));
        }

    }
}
