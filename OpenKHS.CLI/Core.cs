using OpenKHS.CLI.IoC;
using Ninject;
using OpenKHS.CLI.Modules;
using OpenKHS.ViewModels;
using System;
using CommandLine;

namespace OpenKHS.CLI
{
    class Core
    {
        private readonly IKernel _kernel;
        private readonly ParserResult<CommandLineOptions> _parserResult;
        private readonly IFeedbackService _feedbackService;
        private readonly MainViewModel _mainViewModel;

        public Core(string[] args)
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
            
            _parserResult = CommandLine.Parser.Default
                .ParseArguments<CommandLineOptions>(args);
        }

        public void Run()
        {
            // TODO process options from parser result
            _mainViewModel.Load();
            _feedbackService.Present(
                _mainViewModel.LocalCongregationAdminViewModel
                .IndexViewModel.Index);
        }
    }
}