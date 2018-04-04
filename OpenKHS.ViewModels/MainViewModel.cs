using System;
using log4net;
using System.Reflection;
using MvvmDialogs;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        #region Parameters / Properties
        
        public IDialogService DialogService { get; }
        public IDataGateway Gateway { get; }

        public IViewModel CongregationVM { get; }
        public IViewModel PublicTalksVM { get; }
        public IViewModel PmScheduleVM { get; }
        public IViewModel ClmmScheduleVM { get; }

        protected static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructors

        public MainViewModel(IDataGateway gateway, IDialogService dialogService) 
        {
            DialogService = dialogService;
            Gateway = gateway;
            CongregationVM = new CongregationViewModel(gateway);
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
            var dialog = new AboutDialogViewModel();
            DialogService.Show(this, dialog);
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
