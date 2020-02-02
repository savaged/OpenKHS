using System.Threading.Tasks;

namespace OpenKHS.CLI.Modules
{
    public interface IModule
    {
        void Load(string entity);
    }
}