using System;

namespace OpenKHS.Models
{
    public interface ISchedule
    {
        DateTime WeekStarting { get; set; }
        Assignment Attendant1 { get; set; }
        Assignment Attendant2 { get; set; }
        Assignment Attendant3 { get; set; }
        Assignment Attendant4 { get; set; }
        Assignment Platform { get; set; }
        Assignment SoundDesk { get; set; }
        Assignment RovingMic1 { get; set; }
        Assignment RovingMic2 { get; set; }
        Assignment OpeningPrayer { get; set; }
        Assignment ClosingPrayer { get; set; }
        Assignment Chairman { get; set; }
    }
}