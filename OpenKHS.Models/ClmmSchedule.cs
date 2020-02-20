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
                    nameof(Assignee.SchoolBibleReading), assignmentTypes));
            Demo1Pub =
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), assignmentTypes));
            Demo1Asst = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), assignmentTypes));           
            Demo2Pub = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo2), assignmentTypes));
            Demo2Asst = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), assignmentTypes));
            Demo3Pub = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo3), assignmentTypes));
            Demo3Asst = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), assignmentTypes));
            SchoolTalk = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolTalk), assignmentTypes));
            LacPart1 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), assignmentTypes));
            LacPart2 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), assignmentTypes));
            LacPart3 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), assignmentTypes));
            CbsConductor = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsConductor), assignmentTypes));
            CbsReader = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsReader), assignmentTypes));
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