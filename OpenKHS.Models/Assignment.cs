using GalaSoft.MvvmLight;

namespace OpenKHS.Models
{
    public class Assignment : ObservableObject, ILookupEntry
    {
        private int _id;
        private string _name;

        private int _assignmentTypeId;

        public Assignment() 
        {
            _name = string.Empty;
            Assignee = NullAssignee.Default;
        }

        public Assignment(AssignmentType assignmentType)
            : this()
        {
            AssignmentTypeId = assignmentType?.Id ?? NullAssignmentType.Default.Id;
        }

        public Assignment(AssignmentType assignmentType, Assignee assignee)
            : this(assignmentType)
        {
            Assignee = assignee ?? NullAssignee.Default;
        }

        public int Id 
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public int AssigneeId
        {
            get => Assignee?.Id ?? NullAssignee.Default.Id;
            set 
            {
                if (Assignee != null && Assignee != NullAssignee.Default)
                {
                    Assignee.Id = value;
                    RaisePropertyChanged();
                }
            }
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
