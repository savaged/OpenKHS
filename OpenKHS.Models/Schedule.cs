using System;
using System.Collections.Generic;
using OpenKHS.Models.Utils;

namespace OpenKHS.Models
{
    public abstract class Schedule : ModelBase
    {
        private DateTime _weekStarting;

        public Schedule(IList<AssignmentType> assignmentTypes)
        {
            WeekStarting = WeekStartingAdapter
                .GetFirstDateOfWeekIso8601(DateTime.Now);
            Attendant1 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.Attendant), assignmentTypes));
            Attendant2 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.Attendant), assignmentTypes));
            Attendant3 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.Attendant), assignmentTypes));
            Attendant4 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.Attendant), assignmentTypes));           
            OpeningPrayer = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.Prayer), assignmentTypes));
            ClosingPrayer = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.Prayer), assignmentTypes));
            Platform = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.Platform), assignmentTypes));
            SoundDesk = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.SoundDesk), assignmentTypes));
            RovingMic1 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.RovingMic), assignmentTypes));
            RovingMic2 = new Assignment(AssignmentType.GetMatchingAssignmentType(
                nameof(LocalCongregationMember.RovingMic), assignmentTypes));
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
        
        public abstract Assignment Chairman { get; set; }

    }
}