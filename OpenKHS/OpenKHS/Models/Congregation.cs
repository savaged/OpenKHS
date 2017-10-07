
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public class Congregation : ICongregation
    {
        public string Name { get; set; }

        public Friend PublicTalkCoordinator { get; set; }
    }
}
