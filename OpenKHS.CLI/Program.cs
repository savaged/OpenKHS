using System.Threading.Tasks;

namespace OpenKHS.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var core = new Core(args);
            await core.RunAsync();
        }
    }
}
