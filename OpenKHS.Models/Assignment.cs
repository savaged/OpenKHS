namespace OpenKHS.Models
{
    public abstract class Assignment : LookupEntry
    {
        private int _assigneeId;
        private int _assignmentTypeId;

        public Assignment() 
            : this(NullAssignmentType.Default.Id)
        {
        }

        public Assignment(int assignmentTypeId)
        {
            AssignmentType = NullAssignmentType.Default;
            AssignmentTypeId = assignmentTypeId;
            Assignee = new NullAssignee();
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
        public AssignmentType AssignmentType { get; set; }
    }

    public class NullAssignment : Assignment
    {
    }
}
