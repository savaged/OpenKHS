using System;
using log4net;
using System.Reflection;
using MvvmDialogs;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : LocalViewModelBase, IMainViewModel
    {
        #region Parameters / Properties

        private int _selectedIndex;
        private CongregationViewModel _congregationViewModel;
        private PublicTalksViewModel _publicTalksViewModel;
        private PmScheduleViewModel _pmScheduleViewModel;
        private ClmmScheduleViewModel _clmmScheduleViewModel;

        protected static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IDialogService DialogService { get; }

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

        public MainViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;

            _congregationViewModel = new CongregationViewModel();
            // TODO figure out how talks should work
            _publicTalksViewModel = new PublicTalksViewModel();
            _pmScheduleViewModel = new PmScheduleViewModel(_congregationViewModel.Index);
            _clmmScheduleViewModel = new ClmmScheduleViewModel(_congregationViewModel.Index);

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
            Save();
            Log.Info("Closing App");
            RequestClose?.Invoke(this, null);
        }

        private void Save()
        {
            _congregationViewModel.Save();
            _clmmScheduleViewModel.Save();
            _pmScheduleViewModel.Save();
            // TODO _publicTalksViewModel.Save();
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

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedIndex))
            {
                Save();
            }
        }

        #endregion
    }
}
