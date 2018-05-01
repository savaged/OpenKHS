using OpenKHS.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenKHS.Models
{
    public class MeetingPart : ModelBase
    {
        public string Title { get; set; }

        public virtual CongregationMember CongregationMember { get; set; }

        [NotMapped]
        public string DisplayName { get => Title + " " + CongregationMember?.Name; }
    }
}
