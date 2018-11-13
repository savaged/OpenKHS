using System;
using log4net;
using System.Reflection;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using OpenKHS.Interfaces;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : LocalViewModelBase, IMainViewModel
    {
        #region Parameters / Properties

        private int _selectedIndex;
        private CongregationViewModel _congregationViewModel;
        private readonly PublicTalksViewModel _publicTalksViewModel;
        private PmScheduleViewModel _pmScheduleViewModel;
        private ClmmScheduleViewModel _clmmScheduleViewModel;

        protected static readonly ILog Log = 
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IViewModel CongregationVM { get => _congregationViewModel; }
        public IViewModel PublicTalksVM { get => _publicTalksViewModel; } 
        public IViewModel PmScheduleVM { get => _pmScheduleViewModel; }
        public IViewModel ClmmScheduleVM { get => _clmmScheduleViewModel; }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                Save();
                Set(ref _selectedIndex, value);
                Load();
            }
        }

        #endregion

        #region Constructors

        public MainViewModel(DatabaseContext dbContext)
        {
            _congregationViewModel = new CongregationViewModel(dbContext);
            // TODO figure out how talks should work
            _publicTalksViewModel = new PublicTalksViewModel(dbContext);
            _pmScheduleViewModel = new PmScheduleViewModel(dbContext, _congregationViewModel.Index);
            _clmmScheduleViewModel = new ClmmScheduleViewModel(dbContext, _congregationViewModel.Index);
        }

        #endregion

        #region Methods

        public void CloseView()
        {
            Save();
            Log.Info("Closing App");
            RequestClose?.Invoke(this, null);
        }

        private void Save()
        {
            switch (SelectedIndex)
            {
                case 0:
                    _congregationViewModel.Save();
                    break;
                case 1:
                    _clmmScheduleViewModel.Save();
                    break;
                case 2:
                    _pmScheduleViewModel.Save();
                    break;
                case 3:
                    _publicTalksViewModel.Save();
                    break;
            }
        }

        private void Load()
        {
            switch (SelectedIndex)
            {
                case 1:
                    _clmmScheduleViewModel.Load();
                    break;
                case 2:
                    _pmScheduleViewModel.Load();
                    break;
                case 3:
                    _publicTalksViewModel.Load();
                    break;
            }
        }

        #endregion

        #region Commands

        public ICommand ShowAboutDialogCmd { get { return new RelayCommand(OnShowAboutDialog, () => true); } }
        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, () => true); } }

        private void OnShowAboutDialog()
        {
            var about = $"OpenKHS{Environment.NewLine}{Environment.NewLine}" +
                        $"Created by David Savage{Environment.NewLine}" +
                        $"Email: david@savaged.info{Environment.NewLine}" +
                        $"Website: https://github.com/savaged/OpenKHS {Environment.NewLine}" +
                        $"{Environment.NewLine}\"You received free, give free.\" (Mt 10:8b){Environment.NewLine}" +
                        $"{Environment.NewLine}OpenKHS v" +
                        $"{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            MessengerInstance.Send(new UserFeedbackMessage(this, about, "About", UserFeedbackTypes.Information));
        }

        private void OnExitApp()
        {
            CloseView();
        }

        #endregion

        #region Events

        public event EventHandler RequestClose = delegate { };

        #endregion
    }
}
