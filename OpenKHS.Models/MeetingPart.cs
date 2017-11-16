using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class MeetingPart : ModelBase
    {
        public string Title { get; set; }

        public virtual Friend Friend { get; set; }
    }
}
