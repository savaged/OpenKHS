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
            BibleReaders = new List<LocalCongregationMember>();
            AYttMPart1Students = new List<LocalCongregationMember>();
            AYttMPart2Students = new List<LocalCongregationMember>();
            AYttMAssistants = new List<LocalCongregationMember>();
            AYttMBibleStudyStudents = new List<LocalCongregationMember>();
            AYttMTalkStudents = new List<LocalCongregationMember>();
            LacConductors = new List<LocalCongregationMember>();
            CbsConductors = new List<LocalCongregationMember>();
            CbsReaders = new List<LocalCongregationMember>();
        }        

        public List<LocalCongregationMember> TreasuresConductors { get; private set; }

        public List<LocalCongregationMember> GemsConductors { get; private set; }

        public List<LocalCongregationMember> Prayers { get; private set; }

        public List<LocalCongregationMember> BibleReaders { get; private set; }

        public List<LocalCongregationMember> AYttMPart1Students { get; private set; }

        public List<LocalCongregationMember> AYttMAssistants { get; private set; }

        public List<LocalCongregationMember> AYttMPart2Students { get; private set; }

        public List<LocalCongregationMember> AYttMBibleStudyStudents { get; private set; }

        public List<LocalCongregationMember> AYttMTalkStudents { get; private set; }

        public List<LocalCongregationMember> LacConductors { get; private set; }

        public List<LocalCongregationMember> CbsConductors { get; private set; }

        public List<LocalCongregationMember> CbsReaders { get; private set; }

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

            BibleReaders.Clear();
            CongMembers.Where(f => f.ClmmBibleReading).ToList().ForEach(f => {
                if (!BibleReaders.Contains(f)) BibleReaders.Add(f);
            });
            BibleReaders = BibleReaders.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(BibleReaders));

            AYttMPart1Students.Clear();
            CongMembers.Where(f => f.ClmmSchoolInitialCall).ToList().ForEach(f => {
                if (!AYttMPart1Students.Contains(f)) AYttMPart1Students.Add(f);
            });
            AYttMPart1Students = AYttMPart1Students.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(AYttMPart1Students));

            // TODO check part 2 is only return visits??
            AYttMPart2Students.Clear();
            CongMembers.Where(f => f.ClmmSchoolReturnVisit).ToList().ForEach(f => {
                if (!AYttMPart2Students.Contains(f)) AYttMPart2Students.Add(f);
            });
            AYttMPart1Students = AYttMPart2Students.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(AYttMPart2Students));

            AYttMAssistants.Clear();
            CongMembers.Where(f => f.ClmmSchoolAssistant).ToList().ForEach(f => {
                if (!AYttMAssistants.Contains(f)) AYttMAssistants.Add(f);
            });
            AYttMAssistants = AYttMAssistants.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(AYttMAssistants));

            AYttMBibleStudyStudents.Clear();
            CongMembers.Where(f => f.ClmmSchoolBibleStudy).ToList().ForEach(f => {
                if (!AYttMBibleStudyStudents.Contains(f)) AYttMBibleStudyStudents.Add(f);
            });
            AYttMBibleStudyStudents = AYttMBibleStudyStudents.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(AYttMBibleStudyStudents)); 

            AYttMTalkStudents.Clear();
            CongMembers.Where(f => f.ClmmSchoolTalk).ToList().ForEach(f => {
                if (!AYttMTalkStudents.Contains(f)) AYttMTalkStudents.Add(f);
            });
            AYttMTalkStudents = AYttMTalkStudents.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(AYttMTalkStudents));

            LacConductors.Clear();
            CongMembers.Where(f => f.ClmmLacParts).ToList().ForEach(f => {
                if (!LacConductors.Contains(f)) LacConductors.Add(f);
            });
            LacConductors = LacConductors.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(LacConductors));

            CbsConductors.Clear();
            CongMembers.Where(f => f.ClmmCbsConductor).ToList().ForEach(f => {
                if (!CbsConductors.Contains(f)) CbsConductors.Add(f);
            });
            CbsConductors = CbsConductors.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(CbsConductors));

            CbsReaders.Clear();
            CongMembers.Where(f => f.ClmmCbsReader).ToList().ForEach(f => {
                if (!CbsReaders.Contains(f)) CbsReaders.Add(f);
            });
            CbsReaders = CbsReaders.OrderBy(f => f.MeetingAssignmentTally).ToList();
            RaisePropertyChanged(nameof(CbsReaders));
        }
    }
}
