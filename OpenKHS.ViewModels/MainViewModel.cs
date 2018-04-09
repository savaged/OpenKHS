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
        private CongregationViewModel _congregationViewModel;
        private PublicTalksViewModel _publicTalksViewModel;
        private PmScheduleViewModel _pmScheduleViewModel;
        private ClmmScheduleViewModel _clmmScheduleViewModel;

        protected static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IDialogService DialogService { get; }
        public IDataGateway Gateway { get; }

        public IViewModel CongregationVM { get => _congregationViewModel; }
        public IViewModel PublicTalksVM { get => _publicTalksViewModel; } 
        public IViewModel PmScheduleVM { get => _pmScheduleViewModel; }
        public IViewModel ClmmScheduleVM { get => _clmmScheduleViewModel; }

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
            _congregationViewModel = new CongregationViewModel(gateway);
            // TODO figure out how talks should work
            _publicTalksViewModel = new PublicTalksViewModel(gateway);
            _pmScheduleViewModel = new PmScheduleViewModel(gateway, _congregationViewModel.Members);
            _clmmScheduleViewModel = new ClmmScheduleViewModel(gateway, _congregationViewModel.Members);

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
                // TODO is there a better way to auto-save?
                _congregationViewModel.SaveModelObject();
                _pmScheduleViewModel.SaveModelObject();
                //_clmmScheduleViewModel.SaveModelObject();
            }
        }

        public event EventHandler RequestClose;

        #endregion
    }
}
