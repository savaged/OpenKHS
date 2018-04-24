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
            : base(dbContext, congMembers) { }

        protected override PmSchedule GetDefaultSchedule(DateTime weekStarting)
        {
            return DbContext.Index().SingleOrDefault(s => s.WeekStarting == weekStarting);
        }

        protected override void AddModelObjectToDbContext() { if (ModelObject != null) DbContext.Store(ModelObject); }
    }
}
