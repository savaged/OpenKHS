using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ScheduleViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(DatabaseContext dbContext, IList<LocalCongregationMember> congMembers)
            : base(dbContext, congMembers)
        {
        }

        protected override void AddModelObjectToDbContext()
        {
            if (IsValidSchedule())
            {
                Repository.Store(ModelObject);
            }
        }

        protected override void LoadLookups()
        {
            base.LoadLookups();

            CongMembers.Where(f => f.ClmmChairman).ToList()
                .ForEach(f => Chairmen.Add(f));
            Chairmen = Chairmen.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Chairmen));
        }
    }
}
