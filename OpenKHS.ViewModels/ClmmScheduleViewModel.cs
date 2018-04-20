using System;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ScheduleViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(IList<Friend> congMembers) : base(congMembers)
        {
        }

        protected override void LoadSchedule(int week)
        {
            throw new NotImplementedException();
        }
    }
}
