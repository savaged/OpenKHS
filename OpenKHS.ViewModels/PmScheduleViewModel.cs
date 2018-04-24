using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ScheduleViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(IList<Friend> congMembers)
            : base(congMembers)
        {
        }

        protected override void LoadSchedule(DateTime weekStarting)
        {
            var data = new PmSchedule();
            data = DbContext.Index().SingleOrDefault(s => s.WeekStarting == weekStarting);
            Initialise(data);
        }

        protected override void AddModelObjectToDbContext() { if (ModelObject != null) DbContext.Store(ModelObject); }
    }
}
