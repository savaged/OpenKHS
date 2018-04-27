
using System;

namespace OpenKHS.Interfaces
{
    public interface ISchedule : IModel
    {
        DateTime WeekStarting { get; set; }
    }
}
