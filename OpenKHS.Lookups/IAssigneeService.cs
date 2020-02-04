using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.Lookups
{
    public interface IAssigneeService
    {
        IList<T> GetIndex<T>(AssignmentType assignmentType) 
            where T : class, IAssignee;
    }
}