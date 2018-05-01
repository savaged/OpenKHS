using System;
using System.Collections.Generic;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting
    {
        private PublicTalk _publicTalk;
        private CongregationMember _wtConductor;
        private CongregationMember _wtReader;

        public PublicTalk PublicTalk
        {
            get => _publicTalk;
            set => Set(ref _publicTalk, value);
        }

        // TODO add validation to wtconductor and reader property i.e. brother has privilege
        public CongregationMember WtConductor
        {
            get => _wtConductor;
            set => Set(ref _wtConductor, CongregationMember.Swap(ref _wtConductor, value, AssignmentContext.PublicMeeting));
        }

        public CongregationMember WtReader
        {
            get => _wtReader;
            set => Set(ref _wtReader, CongregationMember.Swap(ref _wtReader, value, AssignmentContext.PublicMeeting));
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
