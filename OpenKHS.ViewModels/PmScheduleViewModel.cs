using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PmScheduleViewModel : IndexBoundViewModelBase<PmSchedules, PmSchedule>
    {
        public PmScheduleViewModel(IDataGateway dataGateway, IList<Friend> congMembers) : base(dataGateway)
        {
            Initialise();
            Attendants = congMembers.Where(f => f.Attendant).ToList();
        }

        public IList<Friend> Attendants { get; }
    }
}
