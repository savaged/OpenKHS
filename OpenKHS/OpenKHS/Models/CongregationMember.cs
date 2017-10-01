using System;

namespace OpenKHS.Models
{
    public class CongregationMember
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public bool Baptised { get; set; }

        public DateTime Baptism { get; set; }

        public bool UnbaptisedPublisher { get; set; }

        public bool Child { get; set; }

        public string Mobile { get; set; }

        public string Landline { get; set; }

        public string Email { get; set; }

        public bool Elder { get; set; }

        public bool MinisterialServant { get; set; }

        // TODO add all properties here
    }

    public enum Gender
    {
        Male,
        Female
    }
}
