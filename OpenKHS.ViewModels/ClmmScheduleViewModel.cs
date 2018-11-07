using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ScheduleViewModelBase<ClmmSchedule>
    {
        public ClmmScheduleViewModel(
            DatabaseContext dbContext, IList<LocalCongregationMember> congMembers)
            : base(dbContext, congMembers)
        {
            TreasuresConductors = new List<LocalCongregationMember>();
            GemsConductors = new List<LocalCongregationMember>();
            Prayers = new List<LocalCongregationMember>();
        }        

        public List<LocalCongregationMember> TreasuresConductors { get; private set; }

        public List<LocalCongregationMember> GemsConductors { get; private set; }

        public List<LocalCongregationMember> Prayers { get; private set; }

        public List<LocalCongregationMember> BibleReaders { get; private set; }

        public List<LocalCongregationMember> AYttMPart1Students { get; private set; }

        public List<LocalCongregationMember> AYttMPart2Students { get; private set; }

        public List<LocalCongregationMember> AYttMBibleStudyStudents { get; private set; }

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

            Chairmen.Clear();
            CongMembers.Where(f => f.ClmmChairman).ToList()
                .ForEach(f => Chairmen.Add(f));
            Chairmen = Chairmen.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Chairmen));

            TreasuresConductors.Clear();
            CongMembers.Where(f => f.ClmmTreasures).ToList()
                .ForEach(f => TreasuresConductors.Add(f));
            TreasuresConductors = TreasuresConductors.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(TreasuresConductors));

            GemsConductors.Clear();
            CongMembers.Where(f => f.ClmmGems).ToList()
                .ForEach(f => GemsConductors.Add(f));
            GemsConductors = GemsConductors.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(GemsConductors));

            Prayers.Clear();
            CongMembers.Where(f => f.Prayer).ToList().ForEach(f => {
                if (!Prayers.Contains(f)) Prayers.Add(f);
            });
            Prayers = Prayers.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(Prayers));
        }
    }
}
