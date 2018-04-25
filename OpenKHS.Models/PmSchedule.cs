using System;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting
    {
        private PublicTalk _publicTalk;
        private Friend _wtConductor;
        private Friend _wtReader;

        public PublicTalk PublicTalk
        {
            get => _publicTalk;
            set => Set(ref _publicTalk, value);
        }

        // TODO add validation to wtconductor and reader property i.e. brother has privilege
        public Friend WtConductor
        {
            get => _wtConductor;
            set => Set(ref _wtConductor, value);
        }

        public Friend WtReader
        {
            get => _wtReader;
            set => Set(ref _wtReader, value);
        }

        public override void Publish()
        {
            WtConductor.IncrementTally();
            WtReader.IncrementTally();
            base.Publish();
        }
    }
}
