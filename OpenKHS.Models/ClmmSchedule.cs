using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class ClmmSchedule : ScheduleBase
    {
        public ClmmSchedule() 
            : base()
        {
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
                new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.ClmmChairman), assignmentTypes).Id);
            Treasures = 
                new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.Treasures), assignmentTypes).Id);
            Gems = 
                new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.Gems), assignmentTypes).Id);
            SchoolBibleReading = 
                new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), 
                    assignmentTypes).Id);
            Demo1Publisher =
                new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), 
                    assignmentTypes).Id);
            Demo1Householder = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoHouseholder), 
                    assignmentTypes).Id);           
            Demo2Publisher = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo2), 
                    assignmentTypes).Id);
            Demo2Householder = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoHouseholder), 
                    assignmentTypes).Id);
            Demo3Publisher = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo3), 
                    assignmentTypes).Id);
            Demo3Householder = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoHouseholder), 
                    assignmentTypes).Id);
            SchoolTalk = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolTalk), 
                    assignmentTypes).Id);
            LacPart1 = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), 
                    assignmentTypes).Id);
            LacPart2 = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts),
                    assignmentTypes).Id);
            LacPart3 = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), 
                    assignmentTypes).Id);
            CbsConductor = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsConductor),
                    assignmentTypes).Id);
            CbsReader = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsReader), 
                    assignmentTypes).Id);
        }

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