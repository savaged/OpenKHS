using System;
using OpenKHS.Interfaces;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class Congregation : ModelBase
    {
        public Congregation()
        {
            Members = new List<CongregationMember>();
            Id = 1; // only ever one
        }

        public List<CongregationMember> Members { get; set; }

    }
}
