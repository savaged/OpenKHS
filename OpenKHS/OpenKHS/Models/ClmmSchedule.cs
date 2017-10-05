

namespace OpenKHS.Models
{
    /// <summary>
    /// Christian Life and Ministry Meeting Schedule
    /// </summary>
    public class ClmmSchedule : Meeting
    {
        // TODO add validation to each property i.e. brother has privilege

        public CongregationMember OpeningPrayer { get; set; }

        public CongregationMember Treasures { get; set; }

        public CongregationMember Gems { get; set; }

        public CongregationMember BibleReading { get; set; }

        public CongregationMember PresentationsForMonth { get; set; }

        public AymMeetingPart InitialCall { get; set; }

        public AymMeetingPart ReturnVisit { get; set; }

        public AymMeetingPart BibleStudy { get; set; }

        public AymMeetingPart AyfmTalk { get; set; }

        public LocalMeetingPart LacPart1 { get; set; }

        public LocalMeetingPart LacPart2 { get; set; }

        public LocalMeetingPart LacPart3 { get; set; }

        public CongregationMember CbsConductor { get; set; }

        public CongregationMember CbsReader { get; set; }

        public CircuitVisitMeetingPart CircuitVisitTalk { get; set; }

        public CongregationMember ClosingPrayer { get; set; }
    }
}
