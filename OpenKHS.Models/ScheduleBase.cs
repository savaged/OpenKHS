using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public abstract class ScheduleBase : ObservableObject, ISchedule
    {
        private int _id;
        private DateTime _weekStarting;
        private Assignment _attendant1;

        public ScheduleBase()
        {
            _attendant1 =
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
            _attendant1 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes));
            Attendant2 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes));
            Attendant3 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes));
            Attendant4 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes));
            OpeningPrayer = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes));
            ClosingPrayer = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes));
            Platform = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Platform), assignmentTypes));
            SoundDesk = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.SoundDesk), assignmentTypes));
            RovingMic1 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes));
            RovingMic2 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes));

            Chairman = new NullAssignment();
        }

        public int Id 
        {
            get => _id;
            set => Set(ref _id, value);
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

        public Assignment Attendant1 
        {
            get => _attendant1;
            set
            {
                _attendant1.Assignee?.Assignments?.Add(value);
                Set(ref _attendant1, value);
            }
        }

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