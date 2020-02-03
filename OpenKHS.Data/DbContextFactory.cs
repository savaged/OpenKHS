using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public abstract class DbContextFactoryBase : IDbContextFactory
    {
        protected readonly DbContextOptions<OpenKHSContext> Options;

        public DbContextFactoryBase(
            IConfiguredDbContextOptionsBuilder optionsBuilder)
        {
            Options = optionsBuilder?.Options;
        }

        public virtual OpenKHSContext Create()
        {
            using (var context = new OpenKHSContext(Options))
            {
                context.Database.EnsureCreated();
                context.EnsureSeeded();
            }
            return new OpenKHSContext(Options);
        }

    }
}