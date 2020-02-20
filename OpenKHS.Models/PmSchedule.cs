using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class PmSchedule : ScheduleBase
    {
        public PmSchedule() 
            : base()
        {
            WtReader = new NullAssignment();
            Speaker = string.Empty;
        }

        public PmSchedule(IList<AssignmentType> assignmentTypes)
            : base(assignmentTypes)
        {
            Chairman = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.ClmmChairman), assignmentTypes));
            WtReader = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.WtReader), assignmentTypes));
            Speaker = string.Empty;
        }

        public Assignment WtReader { get; set; }

        public string Speaker { get; set; }
        
    }
}