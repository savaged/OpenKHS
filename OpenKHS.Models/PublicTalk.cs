using System;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class PublicTalk : MeetingPart
    {
        public PublicTalkOutline PublicTalkOutline { get; set; }

        public override string Title
        {
            get => PublicTalkOutline?.Title;
            set => throw new NotSupportedException();
        }
    }
}
