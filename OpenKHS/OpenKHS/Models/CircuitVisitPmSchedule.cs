using Newtonsoft.Json;
using System.IO;

namespace OpenKHS.Models
{
    public class CircuitVisitPmSchedule : PmSchedule
    {
        public CircuitVisitMeetingPart ClosingTalk { get; set; }

        public override void Autofill()
        {
            throw new System.NotImplementedException();
        }

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
