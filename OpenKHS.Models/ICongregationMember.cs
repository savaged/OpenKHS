namespace OpenKHS.Models
{
    public interface ICongregationMember : IModel
    {
        string Name { get; set; }

        int CountPrivileges();
        bool CanAcceptAssignmentType(AssignmentType assignmentType);

    }
}