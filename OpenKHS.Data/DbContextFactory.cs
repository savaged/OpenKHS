using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<OpenKHSContext> _options;

        public DbContextFactory(
            ConfiguredDbContextOptionsBuilder optionsBuilder)
        {
            _options = optionsBuilder?.Options;
        }

        public OpenKHSContext Create()
        {
            using (var context = new OpenKHSContext(_options))
            {
                context.Database.EnsureCreated();
            }
            return new OpenKHSContext(_options);
        }
    }
}