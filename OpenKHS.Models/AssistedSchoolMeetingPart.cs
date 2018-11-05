
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Models
{
    [Owned]
    public class AssistedSchoolMeetingPart : SchoolMeetingPart
    {
        public LocalCongregationMember Assistant { get; set; }
    }
}

