using System;
using GalaSoft.MvvmLight;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(
            MasterDetailViewModel<ClmmSchedule> clmmScheduleAdminViewModel,
            MasterDetailViewModel<LocalCongregationMember> localCongregationAdminViewModel,
            IndexViewModel<Assignment> assignmentsViewModel)
        {
            ClmmScheduleAdminViewModel = clmmScheduleAdminViewModel ??
                throw new ArgumentNullException(nameof(clmmScheduleAdminViewModel));
            LocalCongregationAdminViewModel = localCongregationAdminViewModel ??
                throw new ArgumentNullException(nameof(localCongregationAdminViewModel));
            AssignmentsViewModel = assignmentsViewModel ??
                throw new ArgumentNullException(nameof(assignmentsViewModel));
        }

        public MasterDetailViewModel<LocalCongregationMember> LocalCongregationAdminViewModel
        { get; }

        public MasterDetailViewModel<ClmmSchedule> ClmmScheduleAdminViewModel
        { get; }

        public IndexViewModel<Assignment> AssignmentsViewModel 
        { get; }

        public void Load()
        {
            LocalCongregationAdminViewModel.Load();
        }

    }
}
