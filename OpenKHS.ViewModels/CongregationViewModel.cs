using MvvmDialogs;
using OpenKHS.Facades;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ViewModelBase, IDataViewModel
    {
        private readonly IDataGateway _dataGateway;
        private readonly IDialogService _dialogService;
        private Congregation _congregation;
        private CongregationFacade _facade;
        private Friend _selectedCongMember;

        public CongregationViewModel(IDataGateway dataGateway, IDialogService dialogService)
        {
            _dataGateway = dataGateway;
            _dialogService = dialogService;
            _facade = new CongregationFacade(_dataGateway);
            _congregation = _facade.Show();
            Members = new ObservableCollection<Friend>(_congregation.Members);
            NotifyPropertyChanged("Members");
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

        public ICommand FormSaveCmd { get { return new RelayCommand(OnFormSave, () => true); } }

        private void OnFormSave()
        {
            // TODO figure out how to add new member and save
        }

        public bool New()
        {
            SelectedCongMember = new Friend();
            return true;
        }
    }
}
