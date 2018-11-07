﻿using log4net;
using System;
using System.Reflection;
using System.Windows;
using Ninject;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using System.IO;

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

            Log.Info("Initialising application structure");

            EnsureAppData();

            var iocKernel = new StandardKernel(new IocBindings());
            iocKernel.Settings.AllowNullInjection = true;
            iocKernel.Load(AppDomain.CurrentDomain.GetAssemblies());

            Log.Info("Initialising local database");
            var db = iocKernel.Get<DatabaseContext>();
            db.Database.EnsureCreated();

            var vm = iocKernel.Get<IMainViewModel>();

            _mainWindow = iocKernel.Get<IMainView>();
            _mainWindow.DataContext = vm;
            ShutdownMode = ShutdownMode.OnMainWindowClose;

            Log.Info("Showing main window");
            _mainWindow.Show();
        }

        static void EnsureAppData()
        {
            var Location = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Location += "\\";
            if (!Directory.Exists($"{Location}OpenKHS"))
            {
                Directory.CreateDirectory($"{Location}OpenKHS");
            }
            Location += "OpenKHS\\";
            Log.Info(Location + " ready");
        }

        static void UnhandledExceptionOccured(object sender, UnhandledExceptionEventArgs args)
        {
            // Here change path to the log.txt file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                                                    + "\\OpenKHS\\log.txt";

            // Show a message before closing application
            MessageBox.Show(
                "Oops, something went wrong and the application must close. Please find a " +
                $"report on the issue at: {path}{Environment.NewLine}" +
                "If the problem persist, please contact david@savaged.info.",
                "Unhandled Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            var e = (Exception)args.ExceptionObject;
            Log.Fatal("Application has crashed", e);
        }

    }
}
