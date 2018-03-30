using System;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ModelBoundViewModelBase<PmSchedule>
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
