using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ScheduleViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(DatabaseContext dbContext, IList<Friend> congMembers)
            : base(dbContext, congMembers) { }

        protected override ClmmSchedule GetDefaultSchedule(DateTime weekStarting)
        {
            return DbContext.Index().SingleOrDefault(s => s.WeekStarting == weekStarting);
        }

        protected override void AddModelObjectToDbContext()
        {
            if (IsValidSchedule())
            {
                DbContext.Store(ModelObject);
            }
        }
    }
}
