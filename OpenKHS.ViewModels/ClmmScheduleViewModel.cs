using System;
using System.Collections.Generic;
using OpenKHS.Facades;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ScheduleViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(IList<Friend> congMembers) 
            : base(congMembers, new DbClmmGatewayFacade())
        {
        }

        protected override void LoadSchedule(DateTime weekStarting)
        {
            throw new NotImplementedException();
        }
    }
}
