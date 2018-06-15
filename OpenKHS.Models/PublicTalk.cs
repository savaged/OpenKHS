using System;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class PublicTalk : MeetingPart
    {
        public PublicTalkOutline PublicTalkOutline { get; set; }

        public override string Name
        {
            get => PublicTalkOutline.Name;
            set => throw new NotSupportedException();
        }
    }
}
