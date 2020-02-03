using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class ClmmSchedule : Schedule
    {
        public ClmmSchedule(IList<AssignmentType> assignmentTypes)
            : base(assignmentTypes)
        {
            Chairman = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.ClmmChairman), assignmentTypes));
            Treasures = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.Treasures), assignmentTypes));
            Gems = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.Gems), assignmentTypes));
            SchoolBibleReading = 
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolBibleReading), 
                    assignmentTypes));
            Demo1Publisher =
                new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolBibleReading), 
                    assignmentTypes));
            Demo1Householder = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolDemoHouseholder), 
                    assignmentTypes));           
            Demo2Publisher = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolDemo2), 
                    assignmentTypes));
            Demo2Householder = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolDemoHouseholder), 
                    assignmentTypes));
            Demo3Publisher = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolDemo3), 
                    assignmentTypes));
            Demo3Householder = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolDemoHouseholder), 
                    assignmentTypes));
            SchoolTalk = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.SchoolTalk), 
                    assignmentTypes));
            LacPart1 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.LacParts), 
                    assignmentTypes));
            LacPart2 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.LacParts), 
                    assignmentTypes));
            LacPart3 = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.LacParts), 
                    assignmentTypes));
            CbsConductor = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.CbsConductor),
                    assignmentTypes));
            CbsReader = 
                 new Assignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(LocalCongregationMember.CbsReader), 
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