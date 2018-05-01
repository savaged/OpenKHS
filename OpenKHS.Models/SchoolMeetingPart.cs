
namespace OpenKHS.Models
{
    public class SchoolMeetingPart : MeetingPart
    {
        public int CounselPoint { get; set; }

        public CongregationMember Student { get => base.CongregationMember; private set { } }
    }
}

