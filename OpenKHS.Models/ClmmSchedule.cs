﻿using System;
using System.IO;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    /// <summary>
    /// Christian Life and Ministry Meeting Schedule
    /// </summary>
    public class ClmmSchedule : Meeting
    {
        private CongregationMember _OpeningPrayer;
        private CongregationMember _Treasures;
        private CongregationMember _Gems;
        private CongregationMember _BibleReading;
        private AssistedSchoolMeetingPart _AYttMPart1;
        private AssistedSchoolMeetingPart _AYttMPart2;
        private AssistedSchoolMeetingPart _AYttMBibleStudy;
        private SchoolMeetingPart _SchoolTalk;
        private MeetingPart _LacPart1;
        private MeetingPart _LacPart2;
        private MeetingPart _LacPart3;
        private CongregationMember _CbsConductor;
        private CongregationMember _CbsReader;
        private CongregationMember _ClosingPrayer;

        // TODO add validation to each property i.e. brother has privilege

        public CongregationMember OpeningPrayer
        {
            get => _OpeningPrayer;
            set => Set(ref _OpeningPrayer, value);
        }

        public CongregationMember Treasures
        {
            get => _Treasures;
            set => Set(ref _Treasures, value);
        }

        public CongregationMember Gems
        {
            get => _Gems;
            set => Set(ref _Gems, value);
        }

        public CongregationMember BibleReading
        {
            get => _BibleReading;
            set => Set(ref _BibleReading, value);
        }

        public AssistedSchoolMeetingPart AYttMPart1
        {
            get => _AYttMPart1;
            set => Set(ref _AYttMPart1, value);
        }

        public AssistedSchoolMeetingPart AYttMPart2
        {
            get => _AYttMPart2;
            set => Set(ref _AYttMPart2, value);
        }

        public AssistedSchoolMeetingPart AYttMBibleStudy
        {
            get => _AYttMBibleStudy;
            set => Set(ref _AYttMBibleStudy, value);
        }

        public SchoolMeetingPart AYttMSchoolTalk
        {
            get => _SchoolTalk;
            set => Set(ref _SchoolTalk, value);
        }

        public MeetingPart LacPart1
        {
            get => _LacPart1;
            set => Set(ref _LacPart1, value);
        }

        public MeetingPart LacPart2
        {
            get => _LacPart2;
            set => Set(ref _LacPart2, value);
        }

        public MeetingPart LacPart3
        {
            get => _LacPart3;
            set => Set(ref _LacPart3, value);
        }

        public CongregationMember CbsConductor
        {
            get => _CbsConductor;
            set => Set(ref _CbsConductor, value);
        }

        public CongregationMember CbsReader
        {
            get => _CbsReader;
            set => Set(ref _CbsReader, value);
        }

        public CongregationMember ClosingPrayer
        {
            get => _ClosingPrayer;
            set => Set(ref _ClosingPrayer, value);
        }
    }
}
