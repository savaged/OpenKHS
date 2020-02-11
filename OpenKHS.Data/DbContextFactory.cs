using System.Linq;
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

        public virtual async Task<OpenKHSContext> CreateAsync()
        {
            OpenKHSContext value = null;
            await Task.Run(() =>
            {
                using (var context = new OpenKHSContext(Options))
                {
                    context.Database.EnsureCreated();
                    context.EnsureSeeded();
                }
                value = new OpenKHSContext(Options);
            });
            return value;
        }

    }
}