using System;
using OpenKHS.Interfaces;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    // TODO add validation to each property i.e. brother has privilege
    public abstract class Meeting : ISchedule
    {
        public int Week { get; set; }

        public Friend Chairman { get; set; }

        public Friend Attendant { get; set; }

        public Friend Security { get; set; }

        public Friend SoundDesk { get; set; }

        public Friend Platform { get; set; }

        public Friend RovingMic1 { get; set; }

        public Friend RovingMic2 { get; set; }

        public virtual void Publish()
        {
            Chairman.AssignmentTally++;
            Attendant.AssignmentTally++;
            Security.AssignmentTally++;
            SoundDesk.AssignmentTally++;
            Platform.AssignmentTally++;
            RovingMic1.AssignmentTally++;
            RovingMic2.AssignmentTally++;
        }

        public DateTime GetWeekStartingDate()
        {
            return WeekNumberAdapter.FirstDateOfWeekIso8601(Week);
        }        
    }
}
