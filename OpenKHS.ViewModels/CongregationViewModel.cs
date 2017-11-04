using MvvmDialogs;
using OpenKHS.Facades;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ViewModelBase, IDataViewModel
    {
        private readonly IDataGateway _dataGateway;
        private readonly IDialogService _dialogService;
        private Congregation _congregation;
        private Friend _selectedCongMember;

        public CongregationViewModel(IDataGateway dataGateway, IDialogService dialogService)
        {
            _dataGateway = dataGateway;
            _dialogService = dialogService;
            _congregation = new DataGatewayFacade<Congregation>(_dataGateway).Show();
            if (_congregation.Members.Count > 0)
            {
                Members = new ObservableCollection<Friend>(_congregation.Members);
            } 
            else
            {
                Members = new ObservableCollection<Friend>();
            }
            NotifyPropertyChanged(nameof(Members));
            SelectedCongMember = new Friend();
        }

        public ObservableCollection<Friend> Members { get; }

        public Friend SelectedCongMember
        {
            get => _selectedCongMember;
            set
            {
                _selectedCongMember = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand FormSaveCmd => new RelayCommand(OnFormSave); 

        private void OnFormSave()
        {
            if (!Members.Contains(SelectedCongMember))
            {
                Members.Add(SelectedCongMember);
            }
            _congregation.Members.Clear();
            foreach (var friend in Members)
            {
                _congregation.Members.Add(friend);
            }
            new DataGatewayFacade<Congregation>(_dataGateway).Update(_congregation);
            NotifyPropertyChanged(nameof(Members));
        }

        public bool New()
        {
            SelectedCongMember = new Friend();
            return true;
        }
    }
}
