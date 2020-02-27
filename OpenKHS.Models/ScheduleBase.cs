using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public abstract class ScheduleBase : ObservableObject, ISchedule
    {
        private int _id;
        private DateTime _weekStarting;
        private Assignment _attendant1;
        private Assignment _attendant2;
        private Assignment _attendant3;
        private Assignment _attendant4;

        public ScheduleBase()
        {
            _attendant1 =
            _attendant2 =
            _attendant3 =
            _attendant4 =
            OpeningPrayer =
            ClosingPrayer =
            Platform =
            SoundDesk =
            RovingMic1 =
            RovingMic2 =
            Chairman = 
               NullAssignment.Default;
        }

        public ScheduleBase(IList<AssignmentType> assignmentTypes)
        {
            WeekStarting = WeekStartingAdapter
                .GetFirstDateOfWeekIso8601(DateTime.Now);
            _attendant1 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes), this);
            _attendant2 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes), this);
            _attendant3 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes), this);
            _attendant4 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Attendant), assignmentTypes), this);
            OpeningPrayer = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes), this);
            ClosingPrayer = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Prayer), assignmentTypes), this);
            Platform = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.Platform), assignmentTypes), this);
            SoundDesk = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.SoundDesk), assignmentTypes), this);
            RovingMic1 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes), this);
            RovingMic2 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(Assignee.RovingMic), assignmentTypes), this);

            Chairman = NullAssignment.Default;
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
                Set(ref _attendant1, value);
                _attendant1.Assignee.Assignments.Add(value);
            }
        }

        public Assignment Attendant2 
        {
            get => _attendant2;
            set
            {
                Set(ref _attendant2, value);
                _attendant2.Assignee.Assignments.Add(value);
            }
        }

        public Assignment Attendant3 
        {
            get => _attendant3;
            set
            {
                Set(ref _attendant3, value);
                _attendant3.Assignee.Assignments.Add(value);
            }
        }

        public Assignment Attendant4 
        {
            get => _attendant4;
            set
            {
                Set(ref _attendant4, value);
                _attendant4.Assignee.Assignments.Add(value);
            }
        }

        public Assignment Platform { get; set; }
        public Assignment SoundDesk { get; set; }
        public Assignment RovingMic1 { get; set; }
        public Assignment RovingMic2 { get; set; }

        public Assignment OpeningPrayer { get; set; }

        public Assignment ClosingPrayer { get; set; }

        public Assignment Chairman { get; set; }

    }
}