using System;
using System.Linq;
using System.Collections.Generic;
using OpenKHS.Models.Attributes;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class Friend : ModelBase, IModel
    {
        public Friend()
        {
            Tally = new AssignmentTally();
            if (UnavailablePeriods == null)
            {
                UnavailablePeriods = new List<DateRange>();
            }
        }

        public string Name { get; set; }
        
        public List<DateRange> UnavailablePeriods { get; set; }

        public AssignmentTally Tally { get; set; }

        public int AssignmentTally
        {
            get => (int)Tally;
        }

        #region Privileges

        [Privilege]
        public bool ClmmChairman { get; set; }

        [Privilege]
        public bool ClmmSecondSchoolCounselor { get; set; }

        [Privilege]
        public bool ClmmPrayer { get; set; }

        [Privilege]
        public bool ClmmTreasures { get; set; }

        [Privilege]
        public bool ClmmGems { get; set; }

        [Privilege]
        public bool ClmmBibleReading { get; set; }

        [Privilege]
        public bool ClmmSchoolMonthPresentations { get; set; }

        [Privilege]
        public bool ClmmSchoolInitialCall { get; set; }

        [Privilege]
        public bool ClmmSchoolReturnVisit { get; set; }

        [Privilege]
        public bool ClmmSchoolBibleStudy { get; set; }

        [Privilege]
        public bool ClmmSchoolTalk { get; set; }

        [Privilege]
        public bool ClmmSchoolAssistant { get; set; }

        [Privilege]
        public bool ClmmSecondSchoolOnly { get; set; }

        [Privilege]
        public bool ClmmMainHallOnly { get; set; }

        [Privilege]
        public bool ClmmLacParts { get; set; }

        [Privilege]
        public bool ClmmCbsConductor { get; set; }

        [Privilege]
        public bool ClmmCbsReader { get; set; }

        [Privilege]
        public bool PublicSpeaker { get; set; }

        [Privilege]
        public bool AwaySpeaker { get; set; }

        [Privilege]
        public bool PmChairman { get; set; }

        [Privilege]
        public bool WtReader { get; set; }

        [Privilege]
        public bool Attendant { get; set; }

        [Privilege]
        public bool Security { get; set; }

        [Privilege]
        public bool SoundDesk { get; set; }

        [Privilege]
        public bool Platform { get; set; }

        [Privilege]
        public bool RovingMic { get; set; }

        [Privilege]
        public bool WtConductor { get; set; }


        public int CountPrivileges()
        {
            var count = 0;
            var privileges = GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(PrivilegeAttribute)));
            foreach (var privilege in privileges)
            {
                var val = privilege.GetValue(this);
                if (val is bool && (bool)val) count++;
            }
            return count;
        }

        #endregion

    }

    public class DateRange : ModelBase
    {
        public DateRange()
        {
            if (Start == null)
            {
                Start = DateTime.Now;
            }
            if (End == null)
            {
                End = DateTime.Now;
            }
        }

        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
