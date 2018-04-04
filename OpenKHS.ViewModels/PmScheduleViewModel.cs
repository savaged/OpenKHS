using System;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : IndexBoundViewModelBase<PmSchedules, PmSchedule>
    {
        public PmScheduleViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
            Initialise();
        }
    }
}
