using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ViewModelBase
    {
        private readonly IDataGateway _dataGateway;

        public PmScheduleViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }
    }
}
