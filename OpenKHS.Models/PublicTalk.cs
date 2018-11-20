using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Models
{
    [Owned]
    public class PublicTalk : ModelBase
    {
        private LocalCongregationMember _localSpeaker;
        private VisitingSpeaker _visitingSpeaker;
        private int _outlineId;

        public LocalCongregationMember LocalSpeaker
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

        public int OutlineId
        {
            get => _outlineId;
            set => Set(ref _outlineId, value);
        }
    }
}
