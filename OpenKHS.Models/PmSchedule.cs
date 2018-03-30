using System;
using OpenKHS.Interfaces;

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
    }
}
