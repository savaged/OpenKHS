using System;
using OpenKHS.Interfaces;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class Congregation : ModelBase, ICongregation
    {
        public Congregation()
        {
            Members = new List<Friend>();
        }

        public List<Friend> Members { get; set; }

    }
}
