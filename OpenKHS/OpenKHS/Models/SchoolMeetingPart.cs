
namespace OpenKHS.Models
{
    public class SchoolMeetingPart : MeetingPart
    {
        public int CounselPoint { get; set; }

        public Friend Student { get => base.Friend; private set { } }
    }
}

