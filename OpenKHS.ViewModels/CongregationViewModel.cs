using OpenKHS.Facades;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.ObjectModel;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ViewModelBase
    {
        private readonly IDataGateway _dataGateway;

        private Congregation _congregation;

        public CongregationViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;

            _congregation = new CongregationFacade(_dataGateway).Show();
            Members = new ObservableCollection<Friend>(_congregation.Members);
            NotifyPropertyChanged("Members");
        }

        public ObservableCollection<Friend> Members { get; }
    }
}
