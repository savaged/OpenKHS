using System.Threading.Tasks;
using OpenKHS.Data;

namespace OpenKHS.Test
{
    public class TestDbContextFactory : DbContextFactoryBase
    {
        public TestDbContextFactory(
            IConfiguredDbContextOptionsBuilder optionsBuilder) 
            : base(optionsBuilder)
        {
        }

        public override async Task<OpenKHSContext> CreateAsync()
        {
            using (var context = new OpenKHSContext(Options))
            {
                context.Database.EnsureDeleted();
            }
            return await base.CreateAsync();
        }

   }
}