using OpenKHS.Interfaces;
using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Speaker
    /// </summary>
    public abstract class PmSpeaker : Friend, IBrother
    {
        public PmSpeaker()
        {
            PublicTalks = new List<PublicTalk>();
        }

        public List<PublicTalk> PublicTalks { get; set; }

        public new bool Male { get => true; }
    }
}
