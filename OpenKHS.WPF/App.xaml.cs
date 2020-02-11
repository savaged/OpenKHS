using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Data.StaticData;
using OpenKHS.ViewModels;

namespace OpenKHS.WPF
{
    public partial class App : Application
    {
        private IKernel _kernel;

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(
                    OnCurrentDomainUnhandledException);

            _kernel = new StandardKernel(
                new ViewModelCoreBindings(),
                new DbContextBindings(DbConnectionStrings.LIVE));

            Current.MainWindow = _kernel.Get<MainWindow>();
            var vm = _kernel.Get<MainViewModel>();
            Current.MainWindow.DataContext = vm;
            Current.MainWindow.Show();
            await vm.LoadAsync();
        }

        private static void OnCurrentDomainUnhandledException(
            object sender, UnhandledExceptionEventArgs args)
        {
            HandleException(sender, args.ExceptionObject as Exception);
        }

        private static void HandleException(object sender, Exception ex)
        {
            var msg = $"{Environment.NewLine}{Environment.NewLine}{ex.Message}";
            if (!(ex.InnerException is null))
            {
                msg += $"{Environment.NewLine}Inner Exception: {ex.InnerException?.Message}";
            }
            MessageBox.Show(msg, $"Fatal Error in {sender}", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
