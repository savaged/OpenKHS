using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class CircuitVisitMeetingPart : MeetingPart
    {
        public CongregationMember CircuitOverseer { get => base.CongregationMember; private set { } }
    }
}
