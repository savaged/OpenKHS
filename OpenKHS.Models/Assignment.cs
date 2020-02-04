using System;

namespace OpenKHS.Models
{
    public abstract class Assignment : ModelBase
    {
        private Assignee _assignee;
        private AssignmentType _assignmentType;

        public Assignment() 
            : this(new NullAssignmentType())
        {
        }

        public Assignment(AssignmentType assignmentType)
        {
            _assignmentType = assignmentType ?? new NullAssignmentType();
            _assignee = new NullAssignee();
        }

        public Assignee Assignee
        {
            get => _assignee;
            set => Set(ref _assignee, value);
        }

        public AssignmentType AssignmentType
        {
            get => _assignmentType;
            set => Set(ref _assignmentType, value);
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
