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

        public override OpenKHSContext Create()
        {
            using (var context = new OpenKHSContext(Options))
            {
                context.Database.EnsureDeleted();
            }
            return base.Create();
        }

   }
}