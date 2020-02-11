using System.Collections.Generic;
using System.Threading.Tasks;
using OpenKHS.Models;

namespace OpenKHS.Lookups
{
    public interface IAssignmentTypeService
    {
        Task<IList<AssignmentType>> GetIndexAsync();
    }
}