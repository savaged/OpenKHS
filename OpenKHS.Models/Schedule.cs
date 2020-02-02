using System;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public abstract class Schedule : ModelBase
    {
        private DateTime _weekStarting;

        public Schedule()
        {
            WeekStarting = WeekStartingAdapter
                .GetFirstDateOfWeekIso8601(DateTime.Now);
            OpeningPrayer = new Assignment();
            ClosingPrayer = new Assignment();
            Chairman = new Assignment();
        }

        public DateTime WeekStarting 
        {
            get => _weekStarting;
            set 
            {
                value = WeekStartingAdapter
                    .GetFirstDateOfWeekIso8601(value);
                Set(ref _weekStarting, value);
            }
        }

        public Assignment OpeningPrayer { get; set; }
        
        public Assignment ClosingPrayer { get; set; }
        
        public Assignment Chairman { get; set; }

    }
}