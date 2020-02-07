using System;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.CLI.Modules
{
    public class ShowModule : BaseModule
    {
        private readonly MainViewModel _mainViewModel;

        public ShowModule(
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
                    ShowClmmSchedule();
                    break;
                case nameof(PmSchedule):
                    ShowPmSchedule();
                    break;
                default:
                    ShowAssignee();
                    break;
            }
        }

        private void ShowClmmSchedule()
        {
            // TODO show single record
        }

        private void ShowPmSchedule()
        {
            // TODO show single record
        }

        private void ShowAssignee()
        {
            // TODO show priorities list
        }
   
    }
}
