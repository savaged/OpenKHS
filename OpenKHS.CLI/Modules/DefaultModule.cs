using System;
using OpenKHS.Data;
using OpenKHS.ViewModels;

namespace OpenKHS.CLI.Modules
{
    public class DefaultModule : BaseModule
    {
        private readonly MainViewModel _mainViewModel;

        public DefaultModule(
            IFeedbackService feedbackService,
            MainViewModel mainViewModel)
            : base(feedbackService)
        {
            _mainViewModel = mainViewModel ??
                throw new ArgumentNullException(nameof(mainViewModel));
        }

        public override void Load()
        {
            _mainViewModel.Load();
            FeedbackService.Present(
                _mainViewModel.LocalCongregationAdminViewModel
                .IndexViewModel.Index);
        }
    }
}