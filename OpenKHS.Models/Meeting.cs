using System;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    // TODO add validation to each property i.e. brother has privilege
    public abstract class Meeting : ModelBase, ISchedule
    {
        private DateTime _weekStarting;
        private Friend _chairman;
        private Friend _attendant;
        private Friend _security;
        private Friend _soundDesk;
        private Friend _platform;
        private Friend _rovingMic1;
        private Friend _rovingMic2;

        public DateTime WeekStarting
        {
            get => _weekStarting;
            set => Set(ref _weekStarting, value);
        }

        public Friend Chairman
        {
            get => _chairman;
            set => Set(ref _chairman, Friend.Swap(ref _chairman, value, this, AssignmentContext.Common));
        }

        public Friend Attendant
        {
            get => _attendant;
            set => Set(ref _attendant, Friend.Swap(ref _attendant, value, this, AssignmentContext.Common));
        }

        public Friend Security
        {
            get => _security;
            set => Set(ref _security, Friend.Swap(ref _security, value, this, AssignmentContext.Common));
        }

        public Friend SoundDesk
        {
            get => _soundDesk;
            set => Set(ref _soundDesk, Friend.Swap(ref _soundDesk, value, this, AssignmentContext.Common));
        }

        public Friend Platform
        {
            get => _platform;
            set => Set(ref _platform, Friend.Swap(ref _platform, value, this, AssignmentContext.Common));
        }

        public Friend RovingMic1
        {
            get => _rovingMic1;
            set => Set(ref _rovingMic1, Friend.Swap(ref _rovingMic1, value, this, AssignmentContext.Common));
        }

        public Friend RovingMic2
        {
            get => _rovingMic2;
            set => Set(ref _rovingMic2, Friend.Swap(ref _rovingMic2, value, this, AssignmentContext.Common));
        }   

        public virtual IList<IFriend> Participants
        {
            get
            {
                var participants = new List<IFriend>
                {
                    Chairman, Attendant, Security, SoundDesk, Platform, RovingMic1, RovingMic2
                };
                return participants;
            } 
        }
    }
}
