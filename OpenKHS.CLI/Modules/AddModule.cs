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
                    AddClmmSchedule();
                    break;
                case nameof(Assignment):
                    AddAssignment();
                    break;
                default:
                    AddAssignee();
                    break;
            }
        }

        private void AddClmmSchedule()
        {
            // TODO start here
        }

        private void AddAssignee()
        {
        }

        private void AddAssignment()
        {
            
        }
        
    }
}
