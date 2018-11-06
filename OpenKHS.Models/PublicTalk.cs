using System;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Models
{
    [Owned]
    public class PublicTalk : ModelBase
    {
        public PmSpeaker Speaker { get; set; }

        public PublicTalkOutline PublicTalkOutline { get; set; }

        public string Title
        {
            get => PublicTalkOutline.Name;
        }
    }
}
