using System;

namespace OpenKHS.Models
{
    public class UnavailablePeriod : ModelBase
    {
        private DateTime _start;
        private DateTime _end;

        public UnavailablePeriod(LocalCongregationMember localCongregationMember)
        {
            LocalCongregationMember = localCongregationMember ??
                throw new ArgumentNullException(nameof(localCongregationMember));

            _start = DateTime.Now;
            _end = DateTime.Now;
        }

        public LocalCongregationMember LocalCongregationMember { get; }

        public DateTime Start 
        { 
            get => _start;
            set => Set(ref _start, value);
        }

        public DateTime End
        { 
            get => _end;
            set => Set(ref _end, value);
        }
    }
}