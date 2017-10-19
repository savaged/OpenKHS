using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : ViewModelBase
    {
        private readonly IDataGateway _dataGateway;

        public PublicTalksViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }
    }
}
