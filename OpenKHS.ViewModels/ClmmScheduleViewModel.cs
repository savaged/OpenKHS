using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ScheduleViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(IList<Friend> congMembers)
            : base(congMembers)
        {
        }

        protected override void LoadSchedule(DateTime weekStarting)
        {
            var data = new ClmmSchedule();
            data = DbContext.ClmmSchedules.SingleOrDefault(s => s.WeekStarting == weekStarting);
            Initialise(data);
        }

        protected override void AddModelObjectToDbContext() { if (ModelObject != null) DbContext.Add(ModelObject); }
    }
}
