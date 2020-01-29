using System.Linq;
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
                EnsureSeeded(context);
            }
            return new OpenKHSContext(_options);
        }

        private void EnsureSeeded(OpenKHSContext context)
        {
            var assignmentTypes = context.AssignmentTypes.ToList();
            if (assignmentTypes.Count() == 0)
            {
                var defaults = StaticData.DbSeedData.GetAssignmentTypes();
                foreach (var assignmentType in defaults)
                {
                    context.AssignmentTypes.Add(assignmentType);
                }
                context.SaveChanges();
            }
        }
    }
}