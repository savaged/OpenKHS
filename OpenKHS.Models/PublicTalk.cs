using System;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Models
{
    [Owned]
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
