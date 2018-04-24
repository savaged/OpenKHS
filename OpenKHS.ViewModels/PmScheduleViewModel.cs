using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;
using OpenKHS.Facades;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : ScheduleViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(IList<Friend> congMembers) 
            : base(congMembers, new DbPmScheduleGatewayFacade())
        {
        }

        protected override void LoadSchedule(DateTime weekStaring)
        {
            using (var db = new DatabaseContext())
            {
                var data = db.PmSchedules.SingleOrDefault(s => s.WeekStarting == weekStaring);
                Initialise(data);
            }
        }
    }
}
