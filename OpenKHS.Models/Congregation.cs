
using Newtonsoft.Json;
using OpenKHS.Interfaces;
using System.Collections.Generic;
using System.Collections;

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
