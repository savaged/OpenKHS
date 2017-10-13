using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System.Windows.Input;
using OpenKHS.Views;
using OpenKHS.Utils;
using OpenKHS.Interfaces;
using System;

namespace OpenKHS.ViewModels
{
    class MainViewModel : ViewModelBase, IViewManager
    {
        #region Parameters
        
        public IDialogService DialogService { get; }

        /// <summary>
        /// Title of the application, as displayed in the top bar of the window
        /// </summary>
        public string Title
        {
            get { return "OpenKHS"; }
        }
        #endregion

        #region Constructors
        public MainViewModel(IDialogService dialogService)
        {
            // DialogService is used to handle dialogs
            this.DialogService = dialogService;
        }

        #endregion

        #region Methods



        #endregion

        #region Commands
        public RelayCommand<object> SampleCmdWithArgument { get { return new RelayCommand<object>(OnSampleCmdWithArgument); } }

        public ICommand SaveAsCmd { get { return new RelayCommand(OnSaveAsTest, AlwaysFalse); } }
        public ICommand SaveCmd { get { return new RelayCommand(OnSaveTest, AlwaysFalse); } }
        public ICommand NewCmd { get { return new RelayCommand(OnNewTest, AlwaysFalse); } }
        public ICommand OpenCmd { get { return new RelayCommand(OnOpenTest, AlwaysFalse); } }
        public ICommand ShowAboutDialogCmd { get { return new RelayCommand(OnShowAboutDialog, AlwaysTrue); } }
        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, AlwaysTrue); } }
        

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        private void OnSampleCmdWithArgument(object obj)
        {
            // TODO
        }

        private void OnSaveAsTest()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "Save As",
                Filter = "Sample (.xml)|*.xml",
                CheckFileExists = false,
                OverwritePrompt = true
            };

            bool? success = DialogService.ShowSaveFileDialog(this, settings);
            if (success == true)
            {
                // Do something
                Log.Info("Saving file: " + settings.FileName);
            }
        }
        private void OnSaveTest()
        {
            // TODO
        }
        private void OnNewTest()
        {
            // TODO
        }
        private void OnOpenTest()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "Open",
                Filter = "Sample (.xml)|*.xml",
                CheckFileExists = false
            };

            bool? success = DialogService.ShowOpenFileDialog(this, settings);
            if (success == true)
            {
                // Do something
                Log.Info("Opening file: " + settings.FileName);
            }
        }
        private void OnShowAboutDialog()
        {
            AboutViewModel dialog = new AboutViewModel();
            var result = DialogService.ShowDialog<About>(this, dialog);
        }
        private void OnExitApp()
        {
            CloseView();
        }

        private void CloseView()
        {
            Log.Info("Closing App");
            RequestClose?.Invoke(this, null);
        }
        #endregion

        #region Events

        public event EventHandler RequestClose;

        #endregion
    }
}
