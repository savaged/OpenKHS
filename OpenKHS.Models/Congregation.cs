
using Newtonsoft.Json;
using OpenKHS.Interfaces;
using System.Collections.Generic;
using System.Collections;

namespace OpenKHS.Models
{
    public class Congregation : ICongregation
    {
        public Congregation()
        {
            Members = new List<Friend>();
        }

        public List<Friend> Members { get; set; }

        
        public override string ToString()
        {
            return JsonEncode();
        }

        public string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
