using System;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : IndexBoundViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(IList<Friend> congMembers)
        {
        }
    }
}
