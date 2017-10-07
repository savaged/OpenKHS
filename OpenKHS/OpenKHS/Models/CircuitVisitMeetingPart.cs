using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class CircuitVisitMeetingPart : MeetingPart
    {
        public Friend CircuitOverseer { get => base.Friend; private set { } }
    }
}
