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

        public ICommand ShowAboutDialogCmd { get { return new RelayCommand(OnShowAboutDialog, () => true); } }
        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, () => true); } }
        
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
