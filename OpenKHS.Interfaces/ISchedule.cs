
using System;
using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface ISchedule : IModel
    {
        DateTime WeekStarting { get; set; }

        IList<IFriend> Participants { get; }
    }
}
