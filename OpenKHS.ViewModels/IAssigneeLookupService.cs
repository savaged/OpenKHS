using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public interface IAssigneeLookupService
    {
        IList<Assignee> Attendants { get; }
    }
}