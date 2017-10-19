
using Newtonsoft.Json;
using OpenKHS.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace OpenKHS.Models
{
    public class Congregation : ICongregation
    {
        public string Name { get; set; }

        public Friend PublicTalkCoordinator { get; set; }

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
