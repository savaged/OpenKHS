
using System.Collections.Generic;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Speaker
    /// </summary>
    public abstract class PmSpeaker : Friend
    {
        public PmSpeaker()
        {
            PublicTalks = new List<PublicTalk>();
        }

        public List<PublicTalk> PublicTalks { get; set; }
    }
}
