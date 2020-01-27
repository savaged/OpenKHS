using System;

namespace OpenKHS.Models
{
    public class UnavailablePeriod : ModelBase
    {
        private DateTime _start;
        private DateTime _end;

        public UnavailablePeriod(CongregationMember congregationMember)
        {
            CongregationMember = congregationMember ??
                throw new ArgumentNullException(nameof(congregationMember));

            _start = DateTime.Now;
            _end = DateTime.Now;
        }

        public CongregationMember CongregationMember { get; }

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