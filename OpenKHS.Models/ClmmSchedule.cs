using System;
using System.Collections.Generic;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public class ClmmSchedule : ModelBase, ISchedule
    {
        private DateTime _weekStarting;
        
        public ClmmSchedule() 
        {
            Attendant1 =
            Attendant2 =
            Attendant3 =
            Attendant4 =
            OpeningPrayer =
            ClosingPrayer =
            Platform =
            SoundDesk =
            RovingMic1 =
            RovingMic2 =
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
        {
            WeekStarting = WeekStartingAdapter
                .GetFirstDateOfWeekIso8601(DateTime.Now);
            Attendant1 = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            Attendant2 = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            Attendant3 = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            Attendant4 = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            OpeningPrayer = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes).Id);
            ClosingPrayer = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes).Id);
            Platform = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Platform), assignmentTypes).Id);
            SoundDesk = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.SoundDesk), assignmentTypes).Id);
            RovingMic1 = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes).Id);
            RovingMic2 = new ClmmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes).Id);

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

        public DateTime WeekStarting
        {
            get => _weekStarting;
            set
            {
                value = WeekStartingAdapter
                    .GetFirstDateOfWeekIso8601(value);
                Set(ref _weekStarting, value);
            }
        }

        public Assignment Attendant1 { get; set; }
        public Assignment Attendant2 { get; set; }
        public Assignment Attendant3 { get; set; }
        public Assignment Attendant4 { get; set; }
        public Assignment Platform { get; set; }
        public Assignment SoundDesk { get; set; }
        public Assignment RovingMic1 { get; set; }
        public Assignment RovingMic2 { get; set; }

        public Assignment OpeningPrayer { get; set; }

        public Assignment ClosingPrayer { get; set; }

        public Assignment Chairman { get; set; }

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