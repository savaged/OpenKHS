using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ScheduleViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(DatabaseContext dbContext, IList<Friend> congMembers)
            : base(dbContext, congMembers)
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
