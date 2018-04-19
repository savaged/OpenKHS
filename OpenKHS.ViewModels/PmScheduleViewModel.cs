using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : IndexBoundViewModelBase<PmSchedule>
    {
        public PmScheduleViewModel(IList<Friend> congMembers)
        {
            Attendants = congMembers.Where(f => f.Attendant).ToList();
        }

        public IList<Friend> Attendants { get; }
    }
}
