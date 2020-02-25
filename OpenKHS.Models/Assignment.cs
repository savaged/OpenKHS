using System;
using GalaSoft.MvvmLight;

namespace OpenKHS.Models
{
    public class Assignment : ObservableObject, ILookupEntry
    {
        private int _id;
        private int _assignmentTypeId;
        private int _assigneeId;

        public Assignment() 
        {
            Assignee = NullAssignee.Default;
        }

        public Assignment(AssignmentType assignmentType)
            : this()
        {
            AssignmentTypeId = assignmentType?.Id ?? 
                throw new ArgumentNullException(nameof(assignmentType));
        }

        public Assignment(AssignmentType assignmentType, Assignee assignee)
            : this(assignmentType)
        {
            Assignee = assignee;
        }

        public int Id 
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Name
        {
            get => Assignee?.Name ?? NullAssignee.Default.Name;
        }

        public int AssigneeId
        {
            get => _assigneeId;
            set => Set(ref _assigneeId, value);
        }
        public Assignee Assignee { get; set; }

        public int AssignmentTypeId
        {
            get => _assignmentTypeId;
            set => Set(ref _assignmentTypeId, value);
        }
    }

    public class NullAssignment : Assignment
    {
    }
}
