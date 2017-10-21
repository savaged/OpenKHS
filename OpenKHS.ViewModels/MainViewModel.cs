using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System.Windows.Input;
using OpenKHS.Utils;
using OpenKHS.Interfaces;
using System;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        #region Parameters / Properties
        
        public IDialogService DialogService { get; }
        public IDataGateway Gateway { get; }

        public IDataViewModel CongregationVM { get; }
        public IDataViewModel PublicTalksVM { get; }
        public IDataViewModel PmScheduleVM { get; }
        public IDataViewModel ClmmScheduleVM { get; }

        #endregion

        #region Constructors

        public MainViewModel(IDataGateway gateway, IDialogService dialogService) 
        {
            DialogService = dialogService;
            Gateway = gateway;
            CongregationVM = new CongregationViewModel(gateway, dialogService);
            PublicTalksVM = new PublicTalksViewModel(gateway);
            PmScheduleVM = new PmScheduleViewModel(gateway);
            ClmmScheduleVM = new ClmmScheduleViewModel(gateway);
        }

        #endregion

        #region Methods

        private void CloseView()
        {
            Log.Info("Closing App");
            RequestClose?.Invoke(this, null);
        }

        #endregion

        #region Commands
        public RelayCommand<object> SampleCmdWithArgument { get { return new RelayCommand<object>(OnSampleCmdWithArgument); } }

        public ICommand SaveAsCmd { get { return new RelayCommand(OnSaveAsTest, AlwaysFalse); } }
        public ICommand SaveCmd { get { return new RelayCommand(OnSaveTest, AlwaysFalse); } }
        public ICommand NewCongMemberCmd { get { return new RelayCommand(OnNewCongMember, () => true); } }
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
        private void OnNewCongMember()
        {
            CongregationVM.New();
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
            var dialog = new AboutViewModel();
            var result = DialogService.ShowDialog(this, dialog);
        }
        private void OnExitApp()
        {
            CloseView();
        }

        
        #endregion

        #region Events

        public event EventHandler RequestClose;

        #endregion
    }
}
