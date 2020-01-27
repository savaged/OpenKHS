namespace OpenKHS.Models
{
    public class AssignmentType : Lookup
    {
    }

    public class NullAssignmentType : AssignmentType
    {
        public new int Id => Lookup.Empty.Id;

        public new string Name => Lookup.Empty.Name;
    }
}