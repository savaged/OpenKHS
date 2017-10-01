using OpenKHS.Interfaces;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Speaker
    /// </summary>
    public abstract class PmSpeaker : Friend, IBrother
    {
        public List<PublicTalk> PublicTalks { get; set; }
    }
}
