using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class PmSchedule : ScheduleBase
    {
        public PmSchedule() 
            : base()
        {
            WtReader = NullAssignment.Default;
            Speaker = string.Empty;
        }

        public PmSchedule(IList<AssignmentType> assignmentTypes)
            : base(assignmentTypes)
        {
            Chairman = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.ClmmChairman), assignmentTypes), this);
            WtReader = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.WtReader), assignmentTypes), this);
            Speaker = string.Empty;
        }

        public Assignment WtReader { get; set; }

        public string Speaker { get; set; }
        
    }
}