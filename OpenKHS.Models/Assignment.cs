using System;

namespace OpenKHS.Models
{
    public class Assignment : ModelBase
    {
        private CongregationMember _assignee;
        private DateTime _due;
        private AssignmentType _type;

        public Assignment()
        {
            _due = DateTime.MinValue;
            _type = new NullAssignmentType();
            _assignee = new NullCongregationMember();
        }
        
        public CongregationMember Assignee
        {
            get => _assignee;
            set => Set(ref _assignee, value);
        }

        public DateTime Due
        {
            get => _due;
            set => Set(ref _due, value);
        }

        public AssignmentType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }
    }
}