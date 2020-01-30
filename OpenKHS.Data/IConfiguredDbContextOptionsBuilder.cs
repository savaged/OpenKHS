using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public interface IConfiguredDbContextOptionsBuilder
    {
        DbContextOptions<OpenKHSContext> Options { get; }
    }
}