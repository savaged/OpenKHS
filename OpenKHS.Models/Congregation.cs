using System;
using OpenKHS.Interfaces;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class Congregation : ModelBase
    {
        public Congregation()
        {
            Members = new List<Friend>();
            Id = 1; // only ever one
        }

        public List<Friend> Members { get; set; }

    }
}
