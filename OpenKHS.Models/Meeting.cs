using System;
using OpenKHS.Interfaces;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    // TODO add validation to each property i.e. brother has privilege
    public abstract class Meeting : ModelBase, ISchedule
    {
        public Meeting()
        {
            WeekStarting = WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now);
        }

        public DateTime WeekStarting { get; set; }

        public Friend Chairman { get; set; }

        public Friend Attendant { get; set; }

        public Friend Security { get; set; }

        public Friend SoundDesk { get; set; }

        public Friend Platform { get; set; }

        public Friend RovingMic1 { get; set; }

        public Friend RovingMic2 { get; set; }

        public virtual void Publish()
        {
            Chairman.IncrementTally();
            Attendant.IncrementTally();
            Security.IncrementTally();
            SoundDesk.IncrementTally();
            Platform.IncrementTally();
            RovingMic1.IncrementTally();
            RovingMic2.IncrementTally();
        }      
    }
}
