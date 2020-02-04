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
            var value = NullAssignmentType.Default;
            if (!string.IsNullOrEmpty(privilege) && assignmentTypes != null &&
                assignmentTypes.Any(t => t.Name == privilege))
            {
                value = assignmentTypes.First(t => t.Name == privilege);
            }
            return value;
        }

    }

    public sealed class NullAssignmentType : AssignmentType
    {
        private static readonly AssignmentType _default =
            new NullAssignmentType();

        static NullAssignmentType()
        {
        }

        private NullAssignmentType()
        {
        }

        public static AssignmentType Default => _default;

        public new int Id => NullLookupEntry.Default.Id;

        public new string Name => NullLookupEntry.Default.Name;
    }
}