using System.Collections.Generic;
using System.Threading.Tasks;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public interface IPotentialAssigneeFactory
    {
        void Init();
        IList<Assignee> Attendants { get; }
    }
}