using System;
using System.Collections.Generic;
using OpenKHS.Models.Utils;

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
                new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.ClmmChairman), assignmentTypes).Id);
            WtReader = 
                new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.WtReader), assignmentTypes).Id);
            Speaker = string.Empty;
        }

        public Assignment WtReader { get; set; }

        public string Speaker { get; set; }
        
    }
}