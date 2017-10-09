using OpenKHS.Interfaces;
using System.IO;

namespace OpenKHS.Models
{
    /// <summary>
    /// Christian Life and Ministry Meeting Schedule
    /// </summary>
    public class ClmmSchedule : Meeting, ISchedule
    {
        // TODO add validation to each property i.e. brother has privilege

        public Friend OpeningPrayer { get; set; }

        public Friend Treasures { get; set; }

        public Friend Gems { get; set; }

        public Friend BibleReading { get; set; }

        public Friend PresentationsForMonth { get; set; }

        public AssistedSchoolMeetingPart InitialCall { get; set; }

        public AssistedSchoolMeetingPart ReturnVisit { get; set; }

        public AssistedSchoolMeetingPart BibleStudy { get; set; }

        public SchoolMeetingPart SchoolTalk { get; set; }

        public MeetingPart LacPart1 { get; set; }

        public MeetingPart LacPart2 { get; set; }

        public MeetingPart LacPart3 { get; set; }

        public Friend CbsConductor { get; set; }

        public Friend CbsReader { get; set; }

        public Friend ClosingPrayer { get; set; }

        public void Autofill()
        {
            throw new System.NotImplementedException();
        }

        public string JsonEncode()
        {
            throw new System.NotImplementedException();
        }

        public void Dump(FileStream outputFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
