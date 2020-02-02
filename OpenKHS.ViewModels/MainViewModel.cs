using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(
            MasterDetailViewModel<ClmmSchedule> clmmScheduleAdminViewModel,
            MasterDetailViewModel<LocalCongregationMember> localCongregationAdminViewModel,
            IndexViewModel<AssignmentType> assignmentTypes)
        {
            ClmmScheduleViewModel = clmmScheduleAdminViewModel ??
                throw new ArgumentNullException(nameof(clmmScheduleAdminViewModel));
            LocalCongregationAdminViewModel = localCongregationAdminViewModel ??
                throw new ArgumentNullException(nameof(localCongregationAdminViewModel));
            AssignmentTypesViewModel = assignmentTypes ??
                throw new ArgumentNullException(nameof(assignmentTypes));
        }

        public MasterDetailViewModel<LocalCongregationMember> LocalCongregationAdminViewModel
        { get; }

        public MasterDetailViewModel<ClmmSchedule> ClmmScheduleViewModel
        { get; }

        public IndexViewModel<AssignmentType> AssignmentTypesViewModel { get; }

        public async Task LoadAsync()
        {
            var tasks = new List<Task>
            {
                Task.Run(() => LocalCongregationAdminViewModel.Load()),
                Task.Run(() => AssignmentTypesViewModel.Load())
            };
            await Task.WhenAll(tasks);
        }

    }
}
