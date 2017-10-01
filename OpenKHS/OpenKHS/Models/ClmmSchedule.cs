

namespace OpenKHS.Models
{
    /// <summary>
    /// Christian Life and Ministry Meeting Schedule
    /// </summary>
    public class ClmmSchedule : Meeting
    {
        public CongregationMember OpeningPrayer { get; set; }

        public CongregationMember Treasures { get; set; }

        public CongregationMember Gems { get; set; }

        public CongregationMember BibleReading { get; set; }

        public CongregationMember PresentationsForMonth { get; set; }

        public CongregationMember InitialCall { get; set; }

        public CongregationMember ReturnVisit { get; set; }

        public CongregationMember BibleStudy { get; set; }

        public CongregationMember AyfmTalk { get; set; }

        public LocalMeetingPart LacPart1 { get; set; }

        public LocalMeetingPart LacPart2 { get; set; }

        public LocalMeetingPart LacPart3 { get; set; }

        public CongregationMember CbsConductor { get; set; }

        public CongregationMember CbsReader { get; set; }

        public CircuitVisitMeetingPart CircuitVisitTalk { get; set; }

        public CongregationMember ClosingPrayer { get; set; }
    }
}
