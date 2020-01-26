namespace OpenKHS.Models
{
    public interface IModel
    {
        int Id { get; set; }

        bool IsNew => Id > 1;

        string Name { get; set; }
    }
}