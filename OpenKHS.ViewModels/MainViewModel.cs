using System;
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
            MasterDetailViewModel<Assignee> assigneeAdminViewModel,
            IndexViewModel<Assignment> assignmentsViewModel)
            : base(busyStateManager)
        {
            ClmmScheduleAdminViewModel = clmmScheduleAdminViewModel ??
                throw new ArgumentNullException(nameof(clmmScheduleAdminViewModel));
            AssigneeAdminViewModel = assigneeAdminViewModel ??
                throw new ArgumentNullException(nameof(assigneeAdminViewModel));
            AssignmentsViewModel = assignmentsViewModel ??
                throw new ArgumentNullException(nameof(assignmentsViewModel));

            ReloadCmd = new RelayCommand(OnReload, () => CanExecute);
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

        public IndexViewModel<Assignment> AssignmentsViewModel 
        { get; }

        public void Load()
        {
            AssigneeAdminViewModel.Load();
        }

        private void OnReload()
        {
            MessengerInstance.Send(new BusyMessage(true, this));
            
        }

    }
}
