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
        private LocalCongregationMember _chairman;
        private LocalCongregationMember _attendant;
        private LocalCongregationMember _openingPrayer;
        private LocalCongregationMember _security;
        private LocalCongregationMember _soundDesk;
        private LocalCongregationMember _platform;
        private LocalCongregationMember _rovingMic1;
        private LocalCongregationMember _rovingMic2;

        public DateTime WeekStarting
        {
            get => _weekStarting;
            set => Set(ref _weekStarting, value);
        }

        public LocalCongregationMember OpeningPrayer
        {
            get => _openingPrayer;
            set => Set(ref _openingPrayer, value);
        }

        public LocalCongregationMember Chairman
        {
            get => _chairman;
            set => Set(ref _chairman, LocalCongregationMember.Swap(ref _chairman, value, AssignmentContext.Common));
        }

        public LocalCongregationMember Attendant
        {
            get => _attendant;
            set => Set(ref _attendant, LocalCongregationMember.Swap(ref _attendant, value, AssignmentContext.Common));
        }

        public LocalCongregationMember Security
        {
            get => _security;
            set => Set(ref _security, LocalCongregationMember.Swap(ref _security, value, AssignmentContext.Common));
        }

        public LocalCongregationMember SoundDesk
        {
            get => _soundDesk;
            set => Set(ref _soundDesk, LocalCongregationMember.Swap(ref _soundDesk, value, AssignmentContext.Common));
        }

        public LocalCongregationMember Platform
        {
            get => _platform;
            set => Set(ref _platform, LocalCongregationMember.Swap(ref _platform, value, AssignmentContext.Common));
        }

        public LocalCongregationMember RovingMic1
        {
            get => _rovingMic1;
            set => Set(ref _rovingMic1, LocalCongregationMember.Swap(ref _rovingMic1, value, AssignmentContext.Common));
        }

        public LocalCongregationMember RovingMic2
        {
            get => _rovingMic2;
            set => Set(ref _rovingMic2, LocalCongregationMember.Swap(ref _rovingMic2, value, AssignmentContext.Common));
        }   

        public virtual IList<ICongregationMember> Participants
        {
            get
            {
                var participants = new List<ICongregationMember>
                {
                    Chairman, Attendant, Security, SoundDesk, Platform, RovingMic1, RovingMic2
                };
                return participants;
            } 
        }
    }
}
