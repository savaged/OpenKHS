using System;
using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;

namespace OpenKHS.Models
{
    public class Assignment : ObservableObject, IModel
    {
        private int _id;
        private int _assignmentTypeId;
        private int _scheduleId;
        private int _assigneeId;
        private Assignee _assignee;

        public Assignment() 
        {
            _assignee = NullAssignee.Default;
            AssigneeId = Assignee.Id;
        }

        public Assignment(AssignmentType assignmentType, ScheduleBase schedule)
            : this()
        {
            AssignmentTypeId = assignmentType?.Id ?? 
                throw new ArgumentNullException(nameof(assignmentType));
            ScheduleId = schedule?.Id ?? 
                throw new ArgumentNullException(nameof(schedule));
        }

        public int Id 
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public int AssigneeId
        {
            get => _assigneeId;
            set => Set(ref _assigneeId, value);
        }
        public Assignee Assignee 
        { 
            get => _assignee;
            set => Set(ref _assignee, value);
        }

        [Required]
        public int ScheduleId
        {
            get => _scheduleId;
            set => Set(ref _scheduleId, value);
        }

        [Required]
        public int AssignmentTypeId
        {
            get => _assignmentTypeId;
            set => Set(ref _assignmentTypeId, value);
        }
    }

    public class NullAssignment : Assignment
    {
        private static readonly Assignment _default = new NullAssignment();

        static NullAssignment() { }

        private NullAssignment() { }

        public static Assignment Default => _default;

        public new int Id => -1;
    }
}
