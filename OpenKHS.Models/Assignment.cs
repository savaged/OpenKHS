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
            Assignee = new NullAssignee();
        }

        public Assignment(AssignmentType assignmentType)
            : this()
        {
            AssignmentTypeId = assignmentType?.Id ?? 0;
        }

        public Assignment(AssignmentType assignmentType, Assignee assignee)
            : this(assignmentType)
        {
            Assignee = assignee ?? new NullAssignee();
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
            get => _assignmentTypeId;
            set => Set(ref _assignmentTypeId, value);
        }
    }

    public class NullAssignment : Assignment
    {
    }
}
