using System;
using System.IO;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    /// <summary>
    /// Christian Life and Ministry Meeting Schedule
    /// </summary>
    public class ClmmSchedule : Meeting
    {
        private Friend _OpeningPrayer;
        private Friend _Treasures;
        private Friend _Gems;
        private Friend _BibleReading;
        private Friend _PresentationsForMonth;
        private AssistedSchoolMeetingPart _InitialCall;
        private AssistedSchoolMeetingPart _ReturnVisit;
        private AssistedSchoolMeetingPart _BibleStudy;
        private SchoolMeetingPart _SchoolTalk;
        private MeetingPart _LacPart1;
        private MeetingPart _LacPart2;
        private MeetingPart _LacPart3;
        private Friend _CbsConductor;
        private Friend _CbsReader;
        private Friend _ClosingPrayer;

        // TODO add validation to each property i.e. brother has privilege

        public Friend OpeningPrayer
        {
            get => _OpeningPrayer;
            set => Set(ref _OpeningPrayer, value);
        }

        public Friend Treasures
        {
            get => _Treasures;
            set => Set(ref _Treasures, value);
        }

        public Friend Gems
        {
            get => _Gems;
            set => Set(ref _Gems, value);
        }

        public Friend BibleReading
        {
            get => _BibleReading;
            set => Set(ref _BibleReading, value);
        }

        public Friend PresentationsForMonth
        {
            get => _PresentationsForMonth;
            set => Set(ref _PresentationsForMonth, value);
        }

        public AssistedSchoolMeetingPart InitialCall
        {
            get => _InitialCall;
            set => Set(ref _InitialCall, value);
        }

        public AssistedSchoolMeetingPart ReturnVisit
        {
            get => _ReturnVisit;
            set => Set(ref _ReturnVisit, value);
        }

        public AssistedSchoolMeetingPart BibleStudy
        {
            get => _BibleStudy;
            set => Set(ref _BibleStudy, value);
        }

        public SchoolMeetingPart SchoolTalk
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

        public Friend CbsConductor
        {
            get => _CbsConductor;
            set => Set(ref _CbsConductor, value);
        }

        public Friend CbsReader
        {
            get => _CbsReader;
            set => Set(ref _CbsReader, value);
        }

        public Friend ClosingPrayer
        {
            get => _ClosingPrayer;
            set => Set(ref _ClosingPrayer, value);
        }

        public override void Publish()
        {
            // TODO increment tally for each assigned cong member
            base.Publish();
        }
    }
}
