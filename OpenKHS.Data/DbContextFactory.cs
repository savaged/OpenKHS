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
                EnsureSeeded(context);
            }
            return new OpenKHSContext(Options);
        }

        protected virtual void EnsureSeeded(OpenKHSContext context)
        {
            var assignmentTypes = context.AssignmentTypes;
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