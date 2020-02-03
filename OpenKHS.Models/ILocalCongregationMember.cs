namespace OpenKHS.Models
{
     public interface ILocalCongregationMember : ICongregationMember
    {
        bool AwaySpeaker { get; set; }
        bool SchoolBibleReading { get; set; }
        bool CbsConductor { get; set; }
        bool CbsReader { get; set; }
        bool ClmmChairman { get; set; }
        bool Gems { get; set; }
        bool LacParts { get; set; }
        bool SchoolMainHallOnly { get; set; }
        bool Prayer { get; set; }
        bool SchoolDemoHouseholder { get; set; }
        bool SchoolDemo3 { get; set; }
        bool SchoolDemo1 { get; set; }
        bool SchoolDemo2 { get; set; }
        bool SchoolTalk { get; set; }
        bool SecondSchoolCounselor { get; set; }
        bool SecondSchoolOnly { get; set; }
        bool Treasures { get; set; }
        bool MainWtConductor { get; set; }
        bool Platform { get; set; }
        bool PmChairman { get; set; }
        bool PublicSpeaker { get; set; }
        bool RovingMic { get; set; }
        bool SoundDesk { get; set; }
        bool WtConductor { get; set; }
        bool WtReader { get; set; }

        int CountPrivileges();
        bool CanAcceptAssignmentType(AssignmentType assignmentType);
    }
}