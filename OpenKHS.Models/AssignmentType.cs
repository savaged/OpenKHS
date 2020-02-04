using System.Collections.Generic;
using System.Linq;

namespace OpenKHS.Models
{
    public class AssignmentType : LookupEntry
    {
        public static AssignmentType GetMatchingAssignmentType(
            string privilege,
            IList<AssignmentType> assignmentTypes)
        {
            AssignmentType value = new NullAssignmentType();
            if (!string.IsNullOrEmpty(privilege) && assignmentTypes != null &&
                assignmentTypes.Any(t => t.Name == privilege))
            {
                value = assignmentTypes.First(t => t.Name == privilege);
            }
            return value;
        }

        public new static AssignmentType Empty => new NullAssignmentType();
    }

    public class NullAssignmentType : AssignmentType
    {
        public new int Id => LookupEntry.Empty.Id;

        public new string Name => LookupEntry.Empty.Name;
    }
}