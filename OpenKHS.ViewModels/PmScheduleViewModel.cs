using OpenKHS.Interfaces;
using System;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ViewModelBase, IDataViewModel
    {
        private readonly IDataGateway _dataGateway;

        public PmScheduleViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public bool New()
        {
            throw new NotImplementedException();
        }
    }
}
