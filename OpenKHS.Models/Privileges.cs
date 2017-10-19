

namespace OpenKHS.Models
{
    public class Privileges
    {
        public bool ClmmChairman { get; set; }

        public bool ClmmSecondSchoolCounselor { get; set; }

        public bool ClmmPrayer { get; set; }

        public bool ClmmTreasures { get; set; }

        public bool ClmmGems { get; set; }

        public bool ClmmBibleReading { get; set; }

        public bool ClmmSchoolMonthPresentations { get; set; }

        public bool ClmmSchoolInitialCall { get; set; }

        public bool ClmmSchoolReturnVisit { get; set; }

        public bool ClmmSchoolBibleStudy { get; set; }

        public bool ClmmSchoolTalk { get; set; }

        public bool ClmmSchoolAssistant { get; set; }

        public bool ClmmSecondSchoolOnly { get; set; }

        public bool ClmmMainHallOnly { get; set; }

        public bool ClmmLacParts { get; set; }

        public bool ClmmCbsConductor { get; set; }

        public bool ClmmCbsReader { get; set; }

        public bool PublicSpeaker { get; set; }

        public bool AwaySpeaker { get; set; }

        public bool PmChairman { get; set; }

        public bool WtReader { get; set; }

        public bool Attendant { get; set; }

        public bool Security { get; set; }

        public bool SoundDesk { get; set; }

        public bool Platform { get; set; }

        public bool RovingMic { get; set; }

        public bool WtConductor { get; set; }

        public int Count()
        {
            var count = 0;
            foreach (var prop in this.GetType().GetProperties())
            {
                var val = prop.GetValue(this);
                if (val is bool && (bool)val) count++;
            }
            return count;
        }
    }
}
