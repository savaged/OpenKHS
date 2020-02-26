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
                NullAssignment.Default;
        }

        public ClmmSchedule(IList<AssignmentType> assignmentTypes)
            : base(assignmentTypes)
        {
            Chairman = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.ClmmChairman), assignmentTypes), this);
            Treasures = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.Treasures), assignmentTypes), this);
            Gems = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.Gems), assignmentTypes), this);
            SchoolBibleReading = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), assignmentTypes), this);
            Demo1Pub =
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolBibleReading), assignmentTypes), this);
            Demo1Asst = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), assignmentTypes), this);           
            Demo2Pub = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo2), assignmentTypes), this);
            Demo2Asst = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), assignmentTypes), this);
            Demo3Pub = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemo3), assignmentTypes), this);
            Demo3Asst = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolDemoAsst), assignmentTypes), this);
            SchoolTalk = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.SchoolTalk), assignmentTypes), this);
            LacPart1 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), assignmentTypes), this);
            LacPart2 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), assignmentTypes), this);
            LacPart3 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.LacParts), assignmentTypes), this);
            CbsConductor = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsConductor), assignmentTypes), this);
            CbsReader = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.CbsReader), assignmentTypes), this);
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