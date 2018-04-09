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

        private int _selectedIndex;

        protected static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IDialogService DialogService { get; }
        public IDataGateway Gateway { get; }

        public IViewModel CongregationVM { get; }
        public IViewModel PublicTalksVM { get; } 
        public IViewModel PmScheduleVM { get; }
        public IViewModel ClmmScheduleVM { get; }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }

        #endregion

        #region Constructors

        public MainViewModel(IDataGateway gateway, IDialogService dialogService) 
        {
            DialogService = dialogService;
            Gateway = gateway;
            var cvm = new CongregationViewModel(gateway);
            // TODO figure out how talks should work
            PublicTalksVM = new PublicTalksViewModel(gateway);
            PmScheduleVM = new PmScheduleViewModel(gateway, cvm.Members);
            ClmmScheduleVM = new ClmmScheduleViewModel(gateway, cvm.Members);
            CongregationVM = cvm;

            PropertyChanged += OnPropertyChanged;
        }

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
            base.Cleanup();
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

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedIndex))
            {
                // TODO
                //CongregationVM.SaveModelObject();
                //PmScheduleVM.SaveModelObject();
                //ClmmScheduleVM.SaveModelObject();
            }
        }

        public event EventHandler RequestClose;

        #endregion
    }
}
