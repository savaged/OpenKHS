using System;

namespace OpenKHS.Models
{
    // TODO add validation to each property i.e. brother has privilege
    public class Meeting
    {
        public int Week { get; set; }

        public Friend Chairman { get; set; }

        public Friend Attendant { get; set; }

        public Friend Security { get; set; }

        public Friend SoundDesk { get; set; }

        public Friend Platform { get; set; }

        public Friend RovingMic1 { get; set; }

        public Friend RovingMic2 { get; set; }
    }
}
