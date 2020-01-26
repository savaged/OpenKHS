using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public interface ISchedule : IModel
    {
        DateTime WeekStarting { get; set; }

        IList<ICongregationMember> Participants { get; }
    }
}