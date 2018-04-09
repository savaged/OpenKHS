using OpenKHS.Interfaces;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class PublicTalks : ModelBase
    {
        public IList<PublicTalk> Talks { get; set; }
    }
}
