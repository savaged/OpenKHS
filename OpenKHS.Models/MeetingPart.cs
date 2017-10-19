using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class MeetingPart
    {
        public string Title { get; set; }

        public virtual Friend Friend { get; set; }
    }
}
