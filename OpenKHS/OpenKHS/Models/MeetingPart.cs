using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public abstract class MeetingPart
    {
        public string Title { get; set; }

        public virtual IBrother Brother { get; set; }
    }
}
