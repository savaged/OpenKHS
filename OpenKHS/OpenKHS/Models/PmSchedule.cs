

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting
    {
        public PublicTalk PublicTalk { get; set; }

        public CongregationMember WtConductor { get; set; }

        public CircuitVisitMeetingPart ClosingTalk { get; set; }
    }
}
