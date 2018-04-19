
namespace OpenKHS.Interfaces
{
    public interface IModelBoundViewModel<T> : IViewModel where T : IModel
    {
        T ModelObject { get; set; }

        void Save();
    }
}
