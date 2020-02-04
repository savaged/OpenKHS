using System;

namespace OpenKHS.Models
{
    public class UnavailablePeriod : ModelBase
    {
        private DateTime _start;
        private DateTime _end;

        private int _assigneeId;

        public UnavailablePeriod()
        {
            Assignee = new NullAssignee();
            _start = DateTime.Now;
            _end = DateTime.Now;
        }

        public int AssigneeId
        {
            get => _assigneeId;
            set => Set(ref _assigneeId, value);
        }
        public Assignee Assignee { get; set; }

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