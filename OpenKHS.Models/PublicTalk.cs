using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Models
{
    [Owned]
    public class PublicTalk : ModelBase
    {
        private PmSpeaker _speaker;

        public PmSpeaker Speaker
        {
            get => _speaker;
            set => Set(ref _speaker, value);
        }

        [NotMapped]
        public PublicTalkOutline PublicTalkOutline { get; set; }

        public override string Name => PublicTalkOutline.Name;
    }
}
