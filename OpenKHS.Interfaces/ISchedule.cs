
using System;

namespace OpenKHS.Interfaces
{
    public interface ISchedule : IJsonEncode
    {
        void Publish();        
    }
}
