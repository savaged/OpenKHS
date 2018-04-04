using System;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ModelBoundViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
        }
    }
}
