using System.IO;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Schedule
    /// </summary>
    public class PmSchedule : Meeting, ISchedule
    {
        public PublicTalk PublicTalk { get; set; }

        // TODO add validation to wtconductor and reader property i.e. brother has privilege
        public Friend WtConductor { get; set; }

        public Friend WtReader { get; set; }

        public void Autofill()
        {
            throw new System.NotImplementedException();
        }

        public string JsonEncode()
        {
            throw new System.NotImplementedException();
        }

        public void Dump(FileStream outputFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
