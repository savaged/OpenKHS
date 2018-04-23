using log4net;
using System;
using System.Reflection;
using System.Windows;
using System.ComponentModel;
using Ninject;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using SQLitePCL;

namespace OpenKHS
{
    public partial class App
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static IMainView _mainWindow;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Log.Info("Application Startup");

            // For catching Global uncaught exception
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionOccured);

            Log.Info("Initialising local database");

            using (var db = new DatabaseContext())
            {
                db.Database.EnsureCreated();
            }

            Log.Info("Initialising application structure");

            var iocKernel = new StandardKernel(new IocBindings());
            iocKernel.Load(AppDomain.CurrentDomain.GetAssemblies());
            var vm = iocKernel.Get<IMainViewModel>();

            _mainWindow = iocKernel.Get<IMainView>();
            _mainWindow.DataContext = vm;
            ShutdownMode = ShutdownMode.OnMainWindowClose;

            Log.Info("Showing main window");
            _mainWindow.Show();
        }

        static void UnhandledExceptionOccured(object sender, UnhandledExceptionEventArgs args)
        {
            // Here change path to the log.txt file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                                                    + "\\OpenKHS\\log.txt";

            // Show a message before closing application
            var dialogService = new MvvmDialogs.DialogService();
            dialogService.ShowMessageBox((INotifyPropertyChanged)(_mainWindow.DataContext),
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
