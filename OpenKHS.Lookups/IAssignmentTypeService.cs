using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.Lookups
{
    public interface IAssignmentTypeService
    {
        IList<AssignmentType> GetIndex();
    }
}