using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class CongregationMember : Friend
    {
        public bool Male { get; set; }

        public string Address { get; set; }

        public bool Baptised { get; set; }

        public DateTime Baptism { get; set; }

        public bool UnbaptisedPublisher { get; set; }

        public bool Child { get; set; }

        public bool Elder { get; set; }

        public bool MinisterialServant { get; set; }

        public bool ClmmChairman { get; set; }

        public bool ClmmSecondSchoolCounselor { get; set; }

        public bool ClmmPrayer { get; set; }

        public bool ClmmTreasures { get; set; }

        public bool ClmmGems { get; set; }

        public bool ClmmBibleReading { get; set; }

        public bool ClmmAyfmMonthPresentations { get; set; }

        public bool ClmmAyfmInitialCall { get; set; }

        public bool ClmmAyfmReturnVisit { get; set; }

        public bool ClmmBAyfmibleStudy { get; set; }

        public bool ClmmAyfmTalk { get; set; }

        public bool ClmmAyfmAssistant { get; set; }

        public bool ClmmSecondSchoolOnly { get; set; }

        public bool ClmmMainHallOnly { get; set; }

        public bool ClmmLacParts { get; set; }

        public bool ClmmCbsConductor { get; set; }

        public bool ClmmCbsReader { get; set; }

        public bool PublicSpeaker { get; set; }

        public bool PmChairman { get; set; }

        public bool WtReader { get; set; }

        public bool Attendant { get; set; }

        public bool Security { get; set; }

        public bool SoundDesk { get; set; }

        public bool Platform { get; set; }

        public List<TimeSpan> UnavailablePeriods { get; set; }

        public bool Disfellowshipped { get; set; }

        public bool MovedAway { get; set; }
    }
}
