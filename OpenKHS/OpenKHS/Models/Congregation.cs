
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

        public string JsonEncode()
        {
            throw new System.NotImplementedException();
        }

        public void Dump(FileStream outputFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
