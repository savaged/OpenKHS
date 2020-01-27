using System;

namespace OpenKHS.Models
{
    public class UnavailablePeriod : ModelBase
    {
        private LocalCongregationMember _localCongregationMember;
        private DateTime _start;
        private DateTime _end;

        public UnavailablePeriod()
        {
            _localCongregationMember = new NullLocalCongregationMember();
            _start = DateTime.Now;
            _end = DateTime.Now;
        }

        public LocalCongregationMember LocalCongregationMember 
        {
            get => _localCongregationMember; 
            set => Set(ref _localCongregationMember, value); 
        }

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