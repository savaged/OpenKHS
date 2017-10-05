

namespace OpenKHS.Models
{
    // TODO add validation to each property i.e. brother has privilege
    public abstract class Meeting
    {
        public int Week { get; set; }

        public CongregationMember Chairman { get; set; }

        public CongregationMember Attendant { get; set; }

        public CongregationMember Security { get; set; }

        public CongregationMember SoundDesk { get; set; }

        public CongregationMember Platform { get; set; }

        public CongregationMember RovingMic1 { get; set; }

        public CongregationMember RovingMic2 { get; set; }
    }
}
