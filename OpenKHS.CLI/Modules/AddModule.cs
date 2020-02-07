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
                case nameof(PmSchedule):
                    AddPmSchedule();
                    break;
                default:
                    AddAssignee();
                    break;
            }
        }

        private void AddClmmSchedule()
        {
            // TODO The add option should build an insert statement for the user to run in sqlite3
        }

        private void AddPmSchedule()
        {
            // TODO The add option should build an insert statement for the user to run in sqlite3
        }

        private void AddAssignee()
        {
            // TODO The add option should build an insert statement for the user to run in sqlite3
        }
       
    }
}
