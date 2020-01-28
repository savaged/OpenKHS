using System;
using OpenKHS.Data;

namespace OpenKHS.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO use ninject
            var startup = new Startup();
            using (var context = new OpenKHSContext(startup.DbContextOptions))
            {
                // TODO do stuff
            }
        }
    }
}
