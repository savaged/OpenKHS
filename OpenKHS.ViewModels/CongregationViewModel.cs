using System;
using MvvmDialogs;
using OpenKHS.Facades;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ModelBoundViewModelBase<Congregation>
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
                Members = new ObservableCollection<Friend>
                {
                    new Friend()
                };
            }
            PropertyChanged += OnPropertyChanged;
        }

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
            base.Cleanup();
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedCongMember) && SelectedCongMember != null)
            {
                OnEditSelectedItem(SelectedCongMember);
            }
        }

        public ObservableCollection<Friend> Members { get; }

        public Friend SelectedCongMember
        {
            get => _selectedCongMember;
            set => Set(ref _selectedCongMember, value);
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
        }

        public void OnEditSelectedItem(Friend selectedItem)
        {
            var selectedFriend = selectedItem;
            var vm = new FriendDialogViewModel<Friend>(_dataGateway, _dialogService, selectedFriend);
            var result = _dialogService.ShowDialog(this, vm);
        }

        public bool New()
        {
            SelectedCongMember = new Friend();
            return true;
        }
    }
}
