
using Newtonsoft.Json;
using System;

namespace OpenKHS.Models
{
    public class CircuitVisitClmmSchedule : ClmmSchedule
    {
        public CircuitVisitMeetingPart CircuitVisitOpeningTalk { get; set; }

        public CircuitVisitMeetingPart CircuitVisitClosingTalk { get; set; }

        public override string ToString()
        {
            return JsonEncode();
        }

        public override string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
