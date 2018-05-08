using OpenKHS.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenKHS.Models
{
    public class MeetingPart : ModelBase
    {
        public virtual string Title { get; set; }

        public virtual Friend Friend { get; set; }

        [NotMapped]
        public string DisplayName { get => Title + " " + Friend?.Name; }
    }
}
