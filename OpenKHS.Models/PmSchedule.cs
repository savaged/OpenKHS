using OpenKHS.Interfaces;
using Newtonsoft.Json;
using System;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting, ISchedule
    {
        public PublicTalk PublicTalk { get; set; }

        // TODO add validation to wtconductor and reader property i.e. brother has privilege
        public Friend WtConductor { get; set; }

        public Friend WtReader { get; set; }

        public override void Publish()
        {
            WtConductor.AssignmentTally++;
            WtReader.AssignmentTally++;
            base.Publish();
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
