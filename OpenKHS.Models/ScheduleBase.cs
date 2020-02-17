using System;
using System.Collections.Generic;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public abstract class ScheduleBase : ModelBase, ISchedule
    {
        private DateTime _weekStarting;

        public ScheduleBase()
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
               new NullAssignment();
        }

        public ScheduleBase(IList<AssignmentType> assignmentTypes)
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

            Chairman = new NullAssignment();
        }

        public string Name => WeekStarting.ToString("yyyy-MM-dd");

        public DateTime WeekStarting
        {
            get => _weekStarting;
            set
            {
                value = WeekStartingAdapter
                    .GetFirstDateOfWeekIso8601(value);
                Set(ref _weekStarting, value);
                RaisePropertyChanged(nameof(Name));
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

    }
}