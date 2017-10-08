
using OpenKHS.Interfaces;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class Congregation : ICongregation
    {
        public string Name { get; set; }

        public Friend PublicTalkCoordinator { get; set; }

        public List<Friend> Members { get; set; }
    }
}
