using System;

namespace OpenKHS.Models
{
    public class CircuitVisitClmmSchedule : ClmmSchedule
    {
        public CircuitVisitMeetingPart CircuitVisitOpeningTalk { get; set; }

        public CircuitVisitMeetingPart CircuitVisitClosingTalk { get; set; }
    }
}
