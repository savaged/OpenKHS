using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class LocalCongregation : Congregation
    {
        public LocalCongregation(IList<LocalCongregationMember> members)
        {
            Name = "Local";
            Id = 1; // only ever one

            Members = members ?? new List<LocalCongregationMember>();
        }

        public IList<LocalCongregationMember> Members { get; set; }

    }
}
