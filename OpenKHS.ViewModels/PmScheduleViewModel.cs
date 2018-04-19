using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : SchedulesViewModelBase<PmSchedules, PmSchedule>
    {
        public PmScheduleViewModel(IList<Friend> congMembers)
        {
            Initialise();
            Attendants = congMembers.Where(f => f.Attendant).ToList();
        }

        public IList<Friend> Attendants { get; }
    }
}
