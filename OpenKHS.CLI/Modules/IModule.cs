using System.Threading.Tasks;

namespace OpenKHS.CLI.Modules
{
    public interface IModule
    {
        Task LoadAsync(string entity);
    }
}