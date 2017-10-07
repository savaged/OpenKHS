using OpenKHS.Interfaces;
using System.IO;

namespace OpenKHS.Models
{
    /// <summary>
    /// Christian Life and Ministry Meeting Schedule
    /// </summary>
    public class ClmmSchedule : Meeting, IDumpsJson
    {
        // TODO add validation to each property i.e. brother has privilege

        public CongregationMember OpeningPrayer { get; set; }

        public CongregationMember Treasures { get; set; }

        public CongregationMember Gems { get; set; }

        public CongregationMember BibleReading { get; set; }

        public CongregationMember PresentationsForMonth { get; set; }

        public AssistedSchoolMeetingPart InitialCall { get; set; }

        public AssistedSchoolMeetingPart ReturnVisit { get; set; }

        public AssistedSchoolMeetingPart BibleStudy { get; set; }

        public SchoolMeetingPart SchoolTalk { get; set; }

        public MeetingPart LacPart1 { get; set; }

        public MeetingPart LacPart2 { get; set; }

        public MeetingPart LacPart3 { get; set; }

        public CongregationMember CbsConductor { get; set; }

        public CongregationMember CbsReader { get; set; }

        public CongregationMember ClosingPrayer { get; set; }

        public void Dump(FileStream outputFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
