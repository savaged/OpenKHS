using System;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ModelBoundViewModelBase<ClmmSchedules>
    {
        public ClmmScheduleViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
        }
    }
}
