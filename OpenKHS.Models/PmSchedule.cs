using System;
using System.Collections.Generic;


namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting
    {
        private PublicTalk _publicTalk;
        private LocalCongregationMember _wtConductor;
        private LocalCongregationMember _wtReader;

        public PublicTalk PublicTalk
        {
            get => _publicTalk;
            set => Set(ref _publicTalk, value);
        }

        // TODO add validation to wtconductor and reader property i.e. brother has privilege
        public LocalCongregationMember WtConductor
        {
            get => _wtConductor;
            set => Set(ref _wtConductor, LocalCongregationMember.Swap(ref _wtConductor, value, AssignmentContext.PublicMeeting));
        }

        /// <summary>
        /// Watchtower reader
        /// </summary>
        public LocalCongregationMember WtReader
        {
            get => _wtReader;
            set => Set(ref _wtReader, LocalCongregationMember.Swap(ref _wtReader, value, AssignmentContext.PublicMeeting));
        }

        public override IList<ICongregationMember> Participants
        {
            get
            {
                var participants = base.Participants;
                participants.Add(WtConductor);
                participants.Add(WtReader);
                return participants;
            }
        }
    }
}
