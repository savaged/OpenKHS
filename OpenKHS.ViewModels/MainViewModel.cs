using System;
using GalaSoft.MvvmLight;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(
            LocalCongregationAdminViewModel localCongregationAdminViewModel,
            IndexViewModel<AssignmentType> assignmentTypes)
        {
            LocalCongregationAdminViewModel = localCongregationAdminViewModel ??
                throw new ArgumentNullException(nameof(localCongregationAdminViewModel));
            AssignmentTypesViewModel = assignmentTypes ??
                throw new ArgumentNullException(nameof(assignmentTypes));
        }

        public LocalCongregationAdminViewModel LocalCongregationAdminViewModel
        { get; }

        public IndexViewModel<AssignmentType> AssignmentTypesViewModel { get; }

        public void Load()
        {
            // TODO use task whenall
            LocalCongregationAdminViewModel.Load();
            AssignmentTypesViewModel.Load();
        }

    }
}