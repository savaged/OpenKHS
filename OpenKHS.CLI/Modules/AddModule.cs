using System;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.CLI.Modules
{
    public class AddModule : BaseModule
    {
        private readonly MainViewModel _mainViewModel;

        public AddModule(
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
                    AddClmmSchedules();
                    break;
                case nameof(Assignment):
                    AddAssignments();
                    break;
                default:
                    AddLocalCongregationMembers();
                    break;
            }
        }

        private void AddClmmSchedules()
        {
            // TODO start here
        }

        private void AddLocalCongregationMembers()
        {
        }

        private void AddAssignments()
        {
            
        }
        
    }
}
