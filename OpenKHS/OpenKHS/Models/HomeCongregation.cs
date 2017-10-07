using System.Collections.Generic;
using System.IO;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class HomeCongregation : ICongregation, IDumpsJson
    {
        public string Name { get; set; }

        public List<CongregationMember> Members { get; set; }

        public void Dump(FileStream outputFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
