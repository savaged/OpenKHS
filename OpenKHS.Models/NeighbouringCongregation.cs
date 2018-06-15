using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class NeighbouringCongregation : Congregation
    {
        public NeighbouringCongregation()
        {
            Speakers = new List<PmSpeaker>();
        }

        public List<PmSpeaker> Speakers { get; set; }
    }
}
