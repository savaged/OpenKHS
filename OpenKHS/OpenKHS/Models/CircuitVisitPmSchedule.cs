using Newtonsoft.Json;

namespace OpenKHS.Models
{
    public class CircuitVisitPmSchedule : PmSchedule
    {
        public CircuitVisitMeetingPart ClosingTalk { get; set; }

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
