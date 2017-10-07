using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class PublicTalk : MeetingPart
    {
        public int TalkNumber { get; set; }

        public IBrother Brother { get => (IBrother) base.Friend; }
    }
}
