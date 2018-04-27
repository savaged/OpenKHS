using System;
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
            set => Set(ref _chairman, Friend.Swap(ref _chairman, value));
        }

        public Friend Attendant
        {
            get => _attendant;
            set => Set(ref _attendant, Friend.Swap(ref _attendant, value));
        }

        public Friend Security
        {
            get => _security;
            set => Set(ref _security, Friend.Swap(ref _security, value));
        }

        public Friend SoundDesk
        {
            get => _soundDesk;
            set => Set(ref _soundDesk, Friend.Swap(ref _soundDesk, value));
        }

        public Friend Platform
        {
            get => _platform;
            set => Set(ref _platform, Friend.Swap(ref _platform, value));
        }

        public Friend RovingMic1
        {
            get => _rovingMic1;
            set => Set(ref _rovingMic1, Friend.Swap(ref _rovingMic1, value));
        }

        public Friend RovingMic2
        {
            get => _rovingMic2;
            set => Set(ref _rovingMic2, Friend.Swap(ref _rovingMic2, value));
        }   
    }
}
