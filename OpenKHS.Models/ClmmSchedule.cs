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
            Demo1Pub = 
            Demo1Asst =
            Demo2Pub = 
            Demo2Asst = 
            Demo3Pub =
            Demo3Asst = 
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
            Demo1Pub =
                new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), 
                    assignmentTypes).Id);
            Demo1Asst = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), 
                    assignmentTypes).Id);           
            Demo2Pub = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo2), 
                    assignmentTypes).Id);
            Demo2Asst = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), 
                    assignmentTypes).Id);
            Demo3Pub = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo3), 
                    assignmentTypes).Id);
            Demo3Asst = 
                 new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), 
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
        
        public Assignment Demo1Pub { get; set; }
        public Assignment Demo1Asst { get; set; }

        public Assignment Demo2Pub { get; set; }
        public Assignment Demo2Asst { get; set; }

        public Assignment Demo3Pub { get; set; }
        public Assignment Demo3Asst { get; set; }

        public Assignment SchoolTalk { get; set; }

        public Assignment LacPart1 { get; set; }

        public Assignment LacPart2 { get; set; }

        public Assignment LacPart3 { get; set; }

        public Assignment CbsConductor { get; set; }

        public Assignment CbsReader { get; set; }

    }
}