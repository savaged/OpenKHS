using System;

namespace OpenKHS.Interfaces
{
    public interface IMeetingPart
    {
        IFriend Conductor { get; }

        string Title { get; }
    }
}
