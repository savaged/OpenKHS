using System;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : SchedulesViewModelBase<ClmmSchedules, ClmmSchedule>
    {
        public ClmmScheduleViewModel(IDataGateway dataGateway, IList<Friend> congMembers) : base(dataGateway)
        {
        }
    }
}
