using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : ViewModelBase
    {
        private readonly IDataGateway _dataGateway;

        public CongregationViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        private string _test = "initial value";
        public string Test
        {
            get => _test;
            set
            {
                _test = value;
                NotifyPropertyChanged();
            }
        }
    }
}
