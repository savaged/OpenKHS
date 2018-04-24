using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Data;
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
            var data = new ClmmSchedule();
            using (var db = new DatabaseContext())
            {
                data = db.ClmmSchedules.SingleOrDefault(s => s.WeekStarting == weekStarting);
            }
            Initialise(data);
        }
    }
}
