using System.IO;
using OpenKHS.Interfaces;
using Newtonsoft.Json;

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

        public virtual void Autofill()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return JsonEncode();
        }

        public virtual string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
