using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Models
{
    [Owned]
    public class PublicTalk : ModelBase
    {
        private LocalSpeaker _localSpeaker;
        private VisitingSpeaker _visitingSpeaker;

        public LocalSpeaker LocalSpeaker
        {
            get => _localSpeaker;
            set => Set(ref _localSpeaker, value);
        }

        public VisitingSpeaker VisitingSpeaker
        {
            get => _visitingSpeaker;
            set => Set(ref _visitingSpeaker, value);
        }

        public bool IsSpeakerSelected
        {
            get
            {
                var value = !(LocalSpeaker is null) || !(VisitingSpeaker is null);
                return value;
            }
        }

        [NotMapped]
        public PublicTalkOutline PublicTalkOutline { get; set; }

        public override string Name => PublicTalkOutline?.Name;

        public int? PublicTalkId => PublicTalkOutline?.Id;
    }
}
