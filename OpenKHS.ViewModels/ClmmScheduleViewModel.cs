using System;
using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ScheduleViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(IList<Friend> congMembers) : base(congMembers)
        {
        }

        protected override void LoadSchedule(DateTime weekStarting)
        {
            throw new NotImplementedException();
        }
    }
}
