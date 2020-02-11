using System.Collections.Generic;
using System.Threading.Tasks;
using OpenKHS.Models;

namespace OpenKHS.Lookups
{
    public interface IAssigneeService
    {
        Task<IList<T>> GetIndexAsync<T>(AssignmentType assignmentType) 
            where T : class, IAssignee;
    }
}