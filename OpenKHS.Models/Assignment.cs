using GalaSoft.MvvmLight;

namespace OpenKHS.Models
{
    public class Assignment : ObservableObject, ILookupEntry
    {
        private int _id;
        private string _name;

        public Assignment() 
        {
            _name = string.Empty;
            AssignmentType = NullAssignmentType.Default;
            Assignee = new NullAssignee();
        }

        public Assignment(AssignmentType assignmentType)
            : this()
        {
            AssignmentType = assignmentType;
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
            get => _name;
            set => Set(ref _name, value);
        }

        public int AssigneeId
        {
            get => Assignee?.Id ?? 0;
            set 
            {
                if (Assignee != null)
                {
                    Assignee.Id = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Assignee Assignee { get; set; }

        public int AssignmentTypeId
        {
            get => AssignmentType?.Id ?? 0;
            set 
            {
                if (AssignmentType != null)
                {
                    AssignmentType.Id = value;
                    RaisePropertyChanged();
                }
            }
        }
        public AssignmentType AssignmentType { get; set; }
    }

    public class NullAssignment : Assignment
    {
    }
}
