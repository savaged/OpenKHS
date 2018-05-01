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
        private CongregationMember _chairman;
        private CongregationMember _attendant;
        private CongregationMember _security;
        private CongregationMember _soundDesk;
        private CongregationMember _platform;
        private CongregationMember _rovingMic1;
        private CongregationMember _rovingMic2;

        public DateTime WeekStarting
        {
            get => _weekStarting;
            set => Set(ref _weekStarting, value);
        }

        public CongregationMember Chairman
        {
            get => _chairman;
            set => Set(ref _chairman, CongregationMember.Swap(ref _chairman, value, AssignmentContext.Common));
        }

        public CongregationMember Attendant
        {
            get => _attendant;
            set => Set(ref _attendant, CongregationMember.Swap(ref _attendant, value, AssignmentContext.Common));
        }

        public CongregationMember Security
        {
            get => _security;
            set => Set(ref _security, CongregationMember.Swap(ref _security, value, AssignmentContext.Common));
        }

        public CongregationMember SoundDesk
        {
            get => _soundDesk;
            set => Set(ref _soundDesk, CongregationMember.Swap(ref _soundDesk, value, AssignmentContext.Common));
        }

        public CongregationMember Platform
        {
            get => _platform;
            set => Set(ref _platform, CongregationMember.Swap(ref _platform, value, AssignmentContext.Common));
        }

        public CongregationMember RovingMic1
        {
            get => _rovingMic1;
            set => Set(ref _rovingMic1, CongregationMember.Swap(ref _rovingMic1, value, AssignmentContext.Common));
        }

        public CongregationMember RovingMic2
        {
            get => _rovingMic2;
            set => Set(ref _rovingMic2, CongregationMember.Swap(ref _rovingMic2, value, AssignmentContext.Common));
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
