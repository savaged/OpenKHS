using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public interface IAssigneeLookupService
    {
        IList<T> Attendants<T>() where T : class, IAssignee;
    }
}