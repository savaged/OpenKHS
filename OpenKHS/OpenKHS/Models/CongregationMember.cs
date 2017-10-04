using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class CongregationMember : Friend
    {
        public CongregationMember()
        {
            UnavailablePeriods = new List<TimeSpan>();
        }

        public Privileges Privileges { get; set; }

        public List<TimeSpan> UnavailablePeriods { get; set; }
    }
}
