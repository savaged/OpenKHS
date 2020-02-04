using System;
using OpenKHS.Lookups;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.CLI.Modules
{
    public class ListModule : BaseModule
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IAssignmentTypeService _assignmentTypeService;

        public ListModule(
            IFeedbackService feedbackService,
            MainViewModel mainViewModel,
            IAssignmentTypeService assignmentTypeService)
            : base(feedbackService)
        {
            _mainViewModel = mainViewModel ??
                throw new ArgumentNullException(nameof(mainViewModel));
            _assignmentTypeService = assignmentTypeService ??
                throw new ArgumentNullException(nameof(assignmentTypeService));
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
                    ListAssignees();
                    break;
            }
        }

        private void ListClmmSchedules()
        {
            _mainViewModel.ClmmScheduleAdminViewModel.Load();
            FeedbackService.Present(
                _mainViewModel.ClmmScheduleAdminViewModel
                .IndexViewModel.Index);
        }

        private void ListAssignees()
        {
            FeedbackService.Present(
                _mainViewModel.AssigneeAdminViewModel
                .IndexViewModel.Index);
        }

        private void ListAssignments()
        {
            _mainViewModel.AssignmentsViewModel.Load();
            FeedbackService.Present(
                _mainViewModel.AssignmentsViewModel.Index);
        }

        private void ListAssignmentTypes()
        {
             FeedbackService.Present(
                _assignmentTypeService.GetIndex());
        }
    }
}
