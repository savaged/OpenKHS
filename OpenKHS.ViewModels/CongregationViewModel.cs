using MvvmDialogs;
using OpenKHS.Facades;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.ObjectModel;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ViewModelBase, IDataViewModel
    {
        private readonly IDataGateway _dataGateway;
        private readonly IDialogService _dialogService;
        private Congregation _congregation;
        private CongregationFacade _facade;

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

        public bool New()
        {
            var friendFormDialogVM = new FriendFormDialogViewModel(_dataGateway);
            var result = _dialogService.ShowDialog(this, friendFormDialogVM);
            return (bool)result;
        }
    }
}
