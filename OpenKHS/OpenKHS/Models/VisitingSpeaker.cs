
using System;

namespace OpenKHS.Models
{
    public class VisitingSpeaker : PmSpeaker
    {
        public Congregation Congregation { get; set; }

        public new bool Male { get => true; }
    }
}
