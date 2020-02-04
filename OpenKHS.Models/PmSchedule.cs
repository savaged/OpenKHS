using System;
using System.Collections.Generic;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public class PmSchedule : ModelBase, ISchedule
    {
        private DateTime _weekStarting;
        
        public PmSchedule() 
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
            WtConductor = 
            WtReader =
               new NullAssignment();
            Speaker = string.Empty;
        }

        public PmSchedule(IList<AssignmentType> assignmentTypes)
        {
            WeekStarting = WeekStartingAdapter
                .GetFirstDateOfWeekIso8601(DateTime.Now);
            Attendant1 = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            Attendant2 = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            Attendant3 = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            Attendant4 = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes).Id);
            OpeningPrayer = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes).Id);
            ClosingPrayer = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes).Id);
            Platform = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Platform), assignmentTypes).Id);
            SoundDesk = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.SoundDesk), assignmentTypes).Id);
            RovingMic1 = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes).Id);
            RovingMic2 = new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes).Id);

            Chairman = 
                new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.ClmmChairman), assignmentTypes).Id);
            WtConductor = 
                new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.WtConductor), assignmentTypes).Id);
            WtReader = 
                new PmAssignment(AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.WtReader), assignmentTypes).Id);
            Speaker = string.Empty;
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

        public Assignment WtConductor { get; set; }

        public Assignment WtReader { get; set; }

        public string Speaker { get; set; }
        
    }
}