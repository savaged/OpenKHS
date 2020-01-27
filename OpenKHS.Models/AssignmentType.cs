namespace OpenKHS.Models
{
    public class AssignmentType : Lookup
    {
    }

    public class NullAssignmentType : AssignmentType
    {
        public new int Id => NullLookup.Empty.Id;

        public new string Name => NullLookup.Empty.Name;
    }
}