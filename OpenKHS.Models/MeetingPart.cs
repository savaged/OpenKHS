using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenKHS.Models
{
    [Owned]
    public class MeetingPart : ModelBase
    {
        public virtual Friend Friend { get; set; }

        [NotMapped]
        public string DisplayName { get => Name + " " + Friend?.Name; }
    }
}
