using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public interface IPotentialAssignmentsFactory
    {
        IList<Assignment> Attendants { get; }
    }
}