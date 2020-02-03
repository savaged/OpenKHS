using System;

namespace OpenKHS.Models
{
    public class Assignment : ModelBase
    {
        private LocalCongregationMember _assignee;
        private AssignmentType _type;

        public Assignment() 
            : this(new NullAssignmentType())
        {
        }

        public Assignment(AssignmentType assignmentType)
        {
            _type = assignmentType ?? new NullAssignmentType();
            _assignee = new NullLocalCongregationMember();
        }
        
        public LocalCongregationMember Assignee
        {
            get => _assignee;
            set => Set(ref _assignee, value);
        }

        public AssignmentType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }
    }

    public class NullAssignment : Assignment
    {
        public NullAssignment() 
            : base(new NullAssignmentType())
        {
            Id = -1;
        }
    }
}
