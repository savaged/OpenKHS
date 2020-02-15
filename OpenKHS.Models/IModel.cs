namespace OpenKHS.Models
{
    public interface IModel
    {
        int Id { get; set; }

        // TODO upgrade framework to allow bool IsNew => Id > 1;
        bool IsNew { get; }
    }
}
