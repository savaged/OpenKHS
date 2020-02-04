using System;

namespace OpenKHS.Models
{
    public class UnavailablePeriod : ModelBase
    {
        private Assignee _assignee;
        private DateTime _start;
        private DateTime _end;

        public UnavailablePeriod()
        {
            _assignee = new NullAssignee();
            _start = DateTime.Now;
            _end = DateTime.Now;
        }

        public Assignee Assignee 
        {
            get => _assignee; 
            set => Set(ref _assignee, value); 
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