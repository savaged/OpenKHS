using System;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ModelBoundViewModelBase<ClmmSchedule>
    {
        private readonly IDataGateway _dataGateway;

        public ClmmScheduleViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }
    }
}
