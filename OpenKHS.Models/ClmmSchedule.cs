using OpenKHS.Interfaces;
using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    /// <summary>
    /// Christian Life and Ministry Meeting Schedule
    /// </summary>
    public class ClmmSchedule : Meeting
    {
        private string _Treasures;
        private LocalCongregationMember _TreasuresConductor;
        private LocalCongregationMember _GemsConductor;
        private string _BibleReading;
        private LocalCongregationMember _BibleReader;
        private string _AYttMPart1;
        private LocalCongregationMember _AYttMPart1Student;
        private LocalCongregationMember _AYttMPart1Asst;
        private string _AYttMPart2;
        private LocalCongregationMember _AYttMPart2Student;
        private LocalCongregationMember _AYttMPart2Asst;
        private string _AYttMBibleStudy;
        private LocalCongregationMember _AYttMBibleStudyStudent;
        private LocalCongregationMember _AYttMBibleStudyAsst;
        private string _AYttMTalk;
        private LocalCongregationMember _AYttMTalkStudent;
        private string _LacPart1;
        private LocalCongregationMember _LacPart1Conductor;
        private string _LacPart2;
        private LocalCongregationMember _LacPart2Conductor;
        private string _LacPart3;
        private LocalCongregationMember _LacPart3Conductor;
        private string _Cbs;
        private LocalCongregationMember _CbsConductor;
        private LocalCongregationMember _CbsReader;
        private LocalCongregationMember _ClosingPrayer;

        // TODO add validation to each property i.e. brother has privilege

        public string Treasures
        {
            get => _Treasures;
            set => Set(ref _Treasures, value);
        }

        public LocalCongregationMember TreasuresConductor
        {
            get => _TreasuresConductor;
            set => Set(ref _TreasuresConductor, LocalCongregationMember.Swap(ref _TreasuresConductor, value, AssignmentContext.Treasures));
        }

        public LocalCongregationMember GemsConductor
        {
            get => _GemsConductor;
            set => Set(ref _GemsConductor, value);
        }

        public string BibleReading
        {
            get => _BibleReading;
            set => Set(ref _BibleReading, value);
        }

        public LocalCongregationMember BibleReader
        {
            get => _BibleReader;
            set => Set(ref _BibleReader, value);
        }

        /// <summary>
        /// Apply yourself to the ministry part 1
        /// </summary>
        public string AYttMPart1
        {
            get => _AYttMPart1;
            set => Set(ref _AYttMPart1, value);
        }

        public LocalCongregationMember AYttMPart1Student
        {
            get => _AYttMPart1Student;
            set => Set(ref _AYttMPart1Student, value);
        }

        public LocalCongregationMember AYttMPart1Asst
        {
            get => _AYttMPart1Asst;
            set => Set(ref _AYttMPart1Asst, value);
        }

        public string AYttMPart2
        {
            get => _AYttMPart2;
            set => Set(ref _AYttMPart2, value);
        }

        public LocalCongregationMember AYttMPart2Student
        {
            get => _AYttMPart2Student;
            set => Set(ref _AYttMPart2Student, value);
        }

        public LocalCongregationMember AYttMPart2Asst
        {
            get => _AYttMPart2Asst;
            set => Set(ref _AYttMPart2Asst, value);
        }

        public string AYttMBibleStudy
        {
            get => _AYttMBibleStudy;
            set => Set(ref _AYttMBibleStudy, value);
        }

        public LocalCongregationMember AYttMBibleStudyStudent
        {
            get => _AYttMBibleStudyStudent;
            set => Set(ref _AYttMBibleStudyStudent, value);
        }

        public LocalCongregationMember AYttMBibleStudyAsst
        {
            get => _AYttMBibleStudyAsst;
            set => Set(ref _AYttMBibleStudyAsst, value);
        }

        public string AYttMTalk
        {
            get => _AYttMTalk;
            set => Set(ref _AYttMTalk, value);
        }

        public LocalCongregationMember AYttMTalkStudent
        {
            get => _AYttMTalkStudent;
            set => Set(ref _AYttMTalkStudent, value);
        }

        /// <summary>
        /// Living as Christians part 1
        /// </summary>
        public string LacPart1
        {
            get => _LacPart1;
            set => Set(ref _LacPart1, value);
        }

        public LocalCongregationMember LacPart1Conductor
        {
            get => _LacPart1Conductor;
            set => Set(ref _LacPart1Conductor, value);
        }

        public string LacPart2
        {
            get => _LacPart2;
            set => Set(ref _LacPart2, value);
        }

        public LocalCongregationMember LacPart2Conductor
        {
            get => _LacPart2Conductor;
            set => Set(ref _LacPart2Conductor, value);
        }

        public string LacPart3
        {
            get => _LacPart3;
            set => Set(ref _LacPart3, value);
        }

        public LocalCongregationMember LacPart3Conductor
        {
            get => _LacPart3Conductor;
            set => Set(ref _LacPart3Conductor, value);
        }

        /// <summary>
        /// Congregation Bible study 
        /// </summary>
        public string Cbs
        {
            get => _Cbs;
            set => Set(ref _Cbs, value);
        }

        public LocalCongregationMember CbsConductor
        {
            get => _CbsConductor;
            set => Set(ref _CbsConductor, value);
        }

        public LocalCongregationMember CbsReader
        {
            get => _CbsReader;
            set => Set(ref _CbsReader, value);
        }

        public LocalCongregationMember ClosingPrayer
        {
            get => _ClosingPrayer;
            set => Set(ref _ClosingPrayer, value);
        }

        public override IList<ICongregationMember> Participants
        {
            get
            {
                var participants = base.Participants;
                participants.Add(TreasuresConductor);
                participants.Add(GemsConductor);
                participants.Add(BibleReader);
                participants.Add(AYttMPart1Student);
                participants.Add(AYttMPart2Student);
                participants.Add(AYttMBibleStudyStudent);
                participants.Add(AYttMTalkStudent);
                participants.Add(LacPart1Conductor);
                participants.Add(LacPart2Conductor);
                participants.Add(LacPart3Conductor);
                return participants;
            }
        }
    }
}
