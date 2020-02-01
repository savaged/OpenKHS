using System;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.CLI.Modules
{
    public class ListModule : BaseModule
    {
        private readonly MainViewModel _mainViewModel;

        public ListModule(
            IFeedbackService feedbackService,
            MainViewModel mainViewModel)
            : base(feedbackService)
        {
            _mainViewModel = mainViewModel ??
                throw new ArgumentNullException(nameof(mainViewModel));
        }

        public override void Load(string entity)
        {
            _mainViewModel.Load();
            switch (entity)
            {
                case nameof(ClmmSchedule):
                    ListClmmSchedules();
                    break;
                case nameof(Assignment):
                    ListAssignments();
                    break;
                case nameof(AssignmentType):
                    ListAssignmentTypes();
                    break;
                default:
                    ListLocalCongregationMembers();
                    break;
            }
        }

        private void ListClmmSchedules()
        {
            FeedbackService.Present(
                _mainViewModel.ClmmScheduleViewModel
                .IndexViewModel.Index);
        }

        private void ListLocalCongregationMembers()
        {
            FeedbackService.Present(
                _mainViewModel.LocalCongregationAdminViewModel
                .IndexViewModel.Index);
        }

        private void ListAssignments()
        {
            
        }

        private void ListAssignmentTypes()
        {
            FeedbackService.Present(
                _mainViewModel.AssignmentTypesViewModel.Index);
        }
    }
}