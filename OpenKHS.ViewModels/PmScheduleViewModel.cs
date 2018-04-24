using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;

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
            using (var db = new DatabaseContext())
            {
                data = db.PmSchedules.SingleOrDefault(s => s.WeekStarting == weekStarting);
            }
            Initialise(data);
        }
    }
}
