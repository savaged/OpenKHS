using System;

namespace OpenKHS.Models
{
    public class PublicTalk : ModelBase
    {
        private LocalCongregationMember _localSpeaker;
        private VisitingSpeaker _visitingSpeaker;

        public int? LocalSpeakerId { get; set; }

        public virtual LocalCongregationMember LocalSpeaker
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
    }
}
