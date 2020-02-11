using System.Threading.Tasks;
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
            OpenKHSContext value = null;
            using (var context = new OpenKHSContext(Options))
            {
                context.Database.EnsureCreated();
                context.EnsureSeeded();
            }
            value = new OpenKHSContext(Options);
            return value;
        }

    }
}