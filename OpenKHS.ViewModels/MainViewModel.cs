using System;
using GalaSoft.MvvmLight;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(
            MasterDetailViewModel<ClmmSchedule> clmmScheduleAdminViewModel,
            MasterDetailViewModel<Assignee> assigneeAdminViewModel,
            IndexViewModel<Assignment> assignmentsViewModel)
        {
            ClmmScheduleAdminViewModel = clmmScheduleAdminViewModel ??
                throw new ArgumentNullException(nameof(clmmScheduleAdminViewModel));
            AssigneeAdminViewModel = assigneeAdminViewModel ??
                throw new ArgumentNullException(nameof(assigneeAdminViewModel));
            AssignmentsViewModel = assignmentsViewModel ??
                throw new ArgumentNullException(nameof(assignmentsViewModel));
        }

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

    }
}
