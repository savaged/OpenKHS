using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class ClmmSchedule : Schedule
    {
        public ClmmSchedule() : base()
        {
            Chairman = 
            Treasures = 
            Gems = 
            SchoolBibleReading =
            Demo1Publisher = 
            Demo1Householder =
            Demo2Publisher = 
            Demo2Householder = 
            Demo3Publisher =
            Demo3Householder = 
            SchoolTalk =
            LacPart1 = 
            LacPart2 =
            LacPart3 =
            CbsConductor = 
            CbsReader = 
                new NullAssignment();
        }

        public ClmmSchedule(IList<AssignmentType> assignmentTypes)
            : base(assignmentTypes)
        {
            Chairman = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.ClmmChairman), assignmentTypes));
            Treasures = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.Treasures), assignmentTypes));
            Gems = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.Gems), assignmentTypes));
            SchoolBibleReading = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), 
                    assignmentTypes));
            Demo1Publisher =
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), 
                    assignmentTypes));
            Demo1Householder = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoHouseholder), 
                    assignmentTypes));           
            Demo2Publisher = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo2), 
                    assignmentTypes));
            Demo2Householder = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoHouseholder), 
                    assignmentTypes));
            Demo3Publisher = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo3), 
                    assignmentTypes));
            Demo3Householder = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoHouseholder), 
                    assignmentTypes));
            SchoolTalk = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolTalk), 
                    assignmentTypes));
            LacPart1 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), 
                    assignmentTypes));
            LacPart2 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts),
                    assignmentTypes));
            LacPart3 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), 
                    assignmentTypes));
            CbsConductor = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsConductor),
                    assignmentTypes));
            CbsReader = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsReader), 
                    assignmentTypes));
        }

        public override Assignment Chairman { get; set; }

        public Assignment Treasures { get; set; }

        public Assignment Gems { get; set; }
        
        public Assignment SchoolBibleReading { get; set; }
        
        public Assignment Demo1Publisher { get; set; }
        public Assignment Demo1Householder { get; set; }

        public Assignment Demo2Publisher { get; set; }
        public Assignment Demo2Householder { get; set; }

        public Assignment Demo3Publisher { get; set; }
        public Assignment Demo3Householder { get; set; }

        public Assignment SchoolTalk { get; set; }

        public Assignment LacPart1 { get; set; }

        public Assignment LacPart2 { get; set; }

        public Assignment LacPart3 { get; set; }

        public Assignment CbsConductor { get; set; }

        public Assignment CbsReader { get; set; }

    }
}