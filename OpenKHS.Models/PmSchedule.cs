using System;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting
    {
        public PublicTalk PublicTalk { get; set; }

        // TODO add validation to wtconductor and reader property i.e. brother has privilege
        public Friend WtConductor { get; set; }

        public Friend WtReader { get; set; }

        public override void Publish()
        {
            WtConductor.IncrementTally();
            WtReader.IncrementTally();
            base.Publish();
        }
    }
}
