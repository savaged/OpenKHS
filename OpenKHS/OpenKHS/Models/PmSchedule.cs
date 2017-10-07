using System.IO;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting, IDumpsJson
    {
        public PublicTalk PublicTalk { get; set; }

        // TODO add validation to wtconductor and reader property i.e. brother has privilege
        public CongregationMember WtConductor { get; set; }

        public CongregationMember WtReader { get; set; }

        public void Dump(FileStream outputFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
