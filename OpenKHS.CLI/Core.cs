using OpenKHS.CLI.IoC;
using Ninject;
using OpenKHS.CLI.Modules;
using OpenKHS.ViewModels;
using System;

namespace OpenKHS.CLI
{
    class Core
    {
        private readonly IKernel _kernel;

        private IFeedbackService _feedbackService;
        private MainViewModel _mainViewModel;

        public Core()
        {
            _kernel = new StandardKernel(
                new CoreBindings(),
                new DbContextBindings());

            _feedbackService = _kernel.Get<IFeedbackService>() ??
                throw new InvalidOperationException(
                    $"Missing dependency! {nameof(FeedbackService)}");
            _mainViewModel = _kernel.Get<MainViewModel>() ??
                throw new InvalidOperationException(
                    $"Missing dependency! {nameof(FeedbackService)}");
        }

        public void Run()
        {
            _mainViewModel.Load();
            _feedbackService.Present(
                _mainViewModel.LocalCongregationAdminViewModel
                .IndexViewModel.Index);
        }
    }
}