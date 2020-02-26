using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;

namespace OpenKHS.Models
{
    public class AssignmentType : ObservableObject, ILookupEntry
    {
        private int _id;
        private string _name;

        public AssignmentType()
        {
            _name = string.Empty;
        }

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

        public int Id 
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }

    public sealed class NullAssignmentType : AssignmentType
    {
        private static readonly AssignmentType _default = new NullAssignmentType();

        static NullAssignmentType() { }

        private NullAssignmentType() { }

        public static AssignmentType Default => _default;

        public new int Id => -1;

        public new string Name => string.Empty;
    }
}