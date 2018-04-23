
using System;

namespace OpenKHS.Interfaces
{
    public interface ISchedule : IModel
    {
        void Publish();

        DateTime WeekStarting { get; set; }
    }
}
