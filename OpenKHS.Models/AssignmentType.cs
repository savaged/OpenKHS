using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OpenKHS.Models
{
    public class AssignmentType : LookupEntry
    {
        public static AssignmentType GetMatchingAssignmentType(
            string privilege,
            IList<AssignmentType> assignmentTypes)
        {
            var value = AssignmentType.Empty;
            if (!string.IsNullOrEmpty(privilege) && assignmentTypes != null &&
                assignmentTypes.Any(t => t.Name == privilege))
            {
                value = assignmentTypes.First(t => t.Name == privilege);
            }
            return value;
        }

        [NotMapped]
        public new static AssignmentType Empty => NullAssignmentType.Default;
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

        public new int Id => LookupEntry.Empty.Id;

        public new string Name => LookupEntry.Empty.Name;
    }
}