using log4net;
using System;
using System.Reflection;
using System.Windows;
using System.ComponentModel;
using OpenKHS.ViewModels;
using OpenKHS.Views;
using Ninject;
using OpenKHS.Interfaces;

namespace OpenKHS
{
    public partial class App
    {
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static MainWindow _app;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Log.Info("Application Startup");

            // For catching Global uncaught exception
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionOccured);

            Log.Info("Starting App");

            var iocKernel = new StandardKernel(new IocBindings());
            iocKernel.Load(AppDomain.CurrentDomain.GetAssemblies());
            IViewManager vm = iocKernel.Get<MainViewModel>();
            
            _app = iocKernel.Get<MainWindow>();
            _app.DataContext = vm;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            _app.Show();
        }

        static void UnhandledExceptionOccured(object sender, UnhandledExceptionEventArgs args)
        {
            // Here change path to the log.txt file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                                                    + "\\OpenKHS\\log.txt";

            // Show a message before closing application
            var dialogService = new MvvmDialogs.DialogService();
            dialogService.ShowMessageBox((INotifyPropertyChanged)(_app.DataContext),
                "Oops, something went wrong and the application must close. Please find a " +
                "report on the issue at: " + path + Environment.NewLine +
                "If the problem persist, please contact david@savaged.info.",
                "Unhandled Error",
                MessageBoxButton.OK);

            Exception e = (Exception)args.ExceptionObject;
            Log.Fatal("Application has crashed", e);
        }

        
    }
}
