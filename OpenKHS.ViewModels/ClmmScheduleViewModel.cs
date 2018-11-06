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
            TreasuresConductors = new List<LocalCongregationMember>();
            GemsConductors = new List<LocalCongregationMember>();
        }

        public List<LocalCongregationMember> TreasuresConductors { get; private set; }

        public List<LocalCongregationMember> GemsConductors { get; private set; }

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

            CongMembers.Where(f => f.ClmmTreasures).ToList()
                .ForEach(f => TreasuresConductors.Add(f));
            TreasuresConductors = TreasuresConductors.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(TreasuresConductors));

            CongMembers.Where(f => f.ClmmGems).ToList()
                .ForEach(f => GemsConductors.Add(f));
            GemsConductors = GemsConductors.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(GemsConductors));
        }
    }
}
