using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ninject;
using OpenKHS.Data;

namespace OpenKHS.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            if (startup.Kernel.Get<IDbContextOptions>() 
                is DbContextOptions<OpenKHSContext> dbOptions)
            {
                using (var context = new OpenKHSContext(dbOptions))
                {
                    // TODO do stuff
                }
            }
            else
            {
                throw new InvalidOperationException(
                    "The db options must be correctly setup!");
            }
        }
    }
}
