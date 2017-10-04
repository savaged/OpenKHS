

namespace OpenKHS.Models
{
    public class Friend
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Mobile { get; set; }

        public string Landline { get; set; }

        public string Email { get; set; }

        public virtual bool Male { get; set; }
    }
}
