namespace OpenKHS.Models
{
     public interface ICongregationMember : IFriend
    {
        bool Attendant { get; set; }
        bool AwaySpeaker { get; set; }
        bool ClmmBibleReading { get; set; }
        bool ClmmCbsConductor { get; set; }
        bool ClmmCbsReader { get; set; }
        bool ClmmChairman { get; set; }
        bool ClmmGems { get; set; }
        bool ClmmLacParts { get; set; }
        bool ClmmMainHallOnly { get; set; }
        bool Prayer { get; set; }
        bool ClmmSchoolAssistant { get; set; }
        bool ClmmSchoolBibleStudy { get; set; }
        bool ClmmSchoolInitialCall { get; set; }
        bool ClmmSchoolReturnVisit { get; set; }
        bool ClmmSchoolTalk { get; set; }
        bool ClmmSecondSchoolCounselor { get; set; }
        bool ClmmSecondSchoolOnly { get; set; }
        bool ClmmTreasures { get; set; }
        bool MainWtConductor { get; set; }
        bool Platform { get; set; }
        bool PmChairman { get; set; }
        bool PublicSpeaker { get; set; }
        bool RovingMic { get; set; }
        bool Security { get; set; }
        bool SoundDesk { get; set; }
        bool WtConductor { get; set; }
        bool WtReader { get; set; }

        int CountPrivileges();
    }
}