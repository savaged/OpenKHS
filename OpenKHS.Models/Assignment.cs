using System;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public class Assignment : ModelBase
    {
        private LocalCongregationMember _assignee;
        private DateTime _dueWeekStarting;
        private AssignmentType _type;

        public Assignment()
        {
            _dueWeekStarting = WeekStartingAdapter
                .GetFirstDateOfWeekIso8601(DateTime.Now);
            _type = new NullAssignmentType();
            _assignee = new NullLocalCongregationMember();
        }
        
        public LocalCongregationMember Assignee
        {
            get => _assignee;
            set => Set(ref _assignee, value);
        }

        public DateTime DueWeekStarting
        {
            get => _dueWeekStarting;
            set => Set(ref _dueWeekStarting, value);
        }

        public AssignmentType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }
    }

    public class NullAssignment : Assignment
    {
        public NullAssignment() : base()
        {
            Id = -1;
        }
    }
}