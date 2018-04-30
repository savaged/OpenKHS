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
            set => Set(ref _wtConductor, Friend.Swap(ref _wtConductor, value, this, AssignmentContext.PublicMeeting));
        }

        public Friend WtReader
        {
            get => _wtReader;
            set => Set(ref _wtReader, Friend.Swap(ref _wtReader, value, this, AssignmentContext.PublicMeeting));
        }

        public override IList<IFriend> Participants
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
